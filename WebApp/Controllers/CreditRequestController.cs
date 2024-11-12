using DAL;
using DAL.IService;
using DAL.Models;
using DAL.Models.CreditRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{

    public class CreditRequestController : AppBaseController
    {
        private ICreditRequestService creditRequestService;
        private IAttachFileService attachFileService;
        private ICommonService commonService;
        private IConfiguration config;

        public CreditRequestController(ICreditRequestService creditRequestService, IAttachFileService attachFileService, ICommonService commonService, IConfiguration config)
        {
            this.creditRequestService = creditRequestService;
            this.attachFileService = attachFileService;
            this.commonService = commonService;
            this.config = config;

        }


        public IActionResult Index(string id)
        {

            var filterModel = new CreditRequestFilterModel
            {
                CreditType = id,
                FromDate = Helper.FirtDayOfMonth(),
                ToDate = DateTime.Now.ToString("dd/MM/yyyy"),
            };

            return View(filterModel);
        }

        [HttpPost]
        public DataTableResultModel<CreditRequestGridModel> SearchCreditRequestPaging(CreditRequestFilterModel filter)
        {
            if (filter != null)
            {
                filter.UserName = AuthenInfo().UserName;
            }

            var res = creditRequestService.SearchCreditRequestPaging(filter, false);
            return res;
        }

        // id: id object, id2: credit type, id3: referTUId
        public async Task<IActionResult> CreditRequestDetail(long? id, string id2,long? id3)
        {

            ViewBag.Role = AuthenInfo().Role;
            ViewBag.UserLogin = AuthenInfo().UserName;
            ViewBag.ApproveMatrix = new CreditRequestMatrixModel();
            ViewBag.StatusHistory = new List<StatusHistoryModel>();
            if (id != null && id.Value > 0)
            {
                var viewModel = creditRequestService.GetCreditRequestById(id.Value);
                ViewBag.LstAttachment = await attachFileService.GetAttachmentByObjectId(id.Value, "CreditRequest");
                ViewBag.ApproveMatrix = creditRequestService.GetMatrixApproveByUserCreate(viewModel.CreatedBy);
                ViewBag.StatusHistory = new List<StatusHistoryModel>();
                return View(viewModel);
            }
            else
            {
                string creditCodeRefer = string.Empty;
               
                if (id3.HasValue)
                {
                    var creditRefer = creditRequestService.GetCreditRequestById(id3.Value);
                    creditCodeRefer = creditRefer != null ? creditRefer.Code : string.Empty;
                   
                }

                var viewModel = new CreditRequestViewModel()
                {
                    UserRequest = AuthenInfo().FullName,
                    Id = 0,
                    Status = Contanst.ContractStatus_Nhap,
                    CreaditType = id2,
                    CreatedBy = AuthenInfo().UserName,
                    RequestedAmount = 0,
                    ApprovedAmount = 0,
                    ReferRequestCode= creditCodeRefer
                };
                ViewBag.StatusHistory = new List<StatusHistoryModel>();
                return View(viewModel);
            }




        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreditRequestDetail(IFormCollection formattact, IFormFile postedFile)
        {
            string rootFolder = config["General:RootFolder"];
            string domain = config["General:Domain"];

            var fName = postedFile.FileName;
            string creditRequestId = formattact["attachcreditId"];
            string creditType = formattact["creditType"];

            //======== Step 1: upload to folder ===========

            var folder = $"{rootFolder}\\upload\\credit-request\\{creditRequestId}";
            string filePath = Path.Combine(folder, fName);
            string urlPath = $"{domain}/upload/credit-request/{creditRequestId}/{fName}";


            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            //======== Step 2: save to data ===========

            var attachFile = new AttactFileModel
            {
                Id=0,
                ObjectId = Convert.ToInt64(creditRequestId),
                ObjectType = "CreditRequest",
                FileName = fName,
                FilePath = filePath,
                URLPath = urlPath,
                CreatedBy = AuthenInfo().UserName
            };
            await attachFileService.SaveAttachment(attachFile);
            //=========== get info for view ===============
            long requestId = Convert.ToInt64(creditRequestId);
            var viewModel = creditRequestService.GetCreditRequestById(requestId);
            ViewBag.Role = AuthenInfo().Role;
            ViewBag.UserLogin = AuthenInfo().UserName;
            ViewBag.LstAttachment = await attachFileService.GetAttachmentByObjectId(requestId, "CreditRequest");
            ViewBag.StatusHistory = new List<StatusHistoryModel>();
            return View(viewModel);
           



        }

        [HttpGet]
        public async Task<JsonResult> DeleteAttachment(long attachId)
        {
            
            await attachFileService.DeleteAttactment(attachId);
            return Json(true);
        }

        [HttpGet]
        public async Task<FileResult> DownloadAttachFile(long attachId)
        {
            var attachObj = await attachFileService.GetAttachmentById(attachId);
            byte[] fileBytes = null;
            if (attachObj != null)
            {
                fileBytes = System.IO.File.ReadAllBytes(attachObj.FilePath);
                string fileName = attachObj.FileName;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
            {
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, string.Empty);
            }
        }



        [HttpPost]
        public async Task<JsonResult> SaveCreditRequest([FromBody] CreditRequestViewModel model)
        {
            var res = await creditRequestService.SaveCreditRequest(model,AuthenInfo().UserName);


            return Json(res);
        }

       

        [HttpPost]
        public JsonResult ChangeCreditRequestStatus([FromBody] ChangeStatusRequestParamModel model)
        {
            model.userName = AuthenInfo().UserName;
            var res = creditRequestService.ChangeStatusRequestCredit(model);
            return Json(res);
        }



        //========================= credit item ================================




        [HttpGet]
        public IActionResult _PartialCreditItemDetail(long id, long requestId)
        {
            var model = new CreditRequestItemModel();
            if (id != 0)
            {
                model = creditRequestService.GetCreditRequestItemById(id);
            }
            model.CreditRequestId = requestId;
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult SaveCreditRequestItem([FromBody] CreditRequestItemModel model)
        {

            var res = creditRequestService.SaveCreditRequestItem(model);
            return Json(res);
        }

        [HttpGet]
        public List<CreditRequestItemModel> ListItemByCreditId(long requestId)
        {
            var res = creditRequestService.ListItemByCreditId(requestId);
            return res;
        }


        [HttpGet]
        public JsonResult DeleteItem(long itemId)
        {
            creditRequestService.DeleteItem(itemId);
            return Json(true);
        }

        public async Task<IActionResult> PrintViewHU(long huId)
        {
            string rootFolder = config["General:RootFolder"];

            var headerHU = creditRequestService.GetCreditRequestById(huId);
            decimal huAmount = headerHU.RequestedAmount.HasValue ? headerHU.RequestedAmount.Value : 0;
            decimal tuAmount = 0;
            if (!string.IsNullOrEmpty(headerHU.ReferRequestCode))
            {
                var headerTU = creditRequestService.GetCreditRequestByCode(headerHU.ReferRequestCode);
                if (headerTU != null)
                {
                    tuAmount = headerTU.ApprovedAmount.HasValue ? headerTU.ApprovedAmount.Value : 0;
                }
            }
            var lstStatusHistory = new List<StatusHistoryModel>();
            var viewModel = new CreditPdfViewModel
            {
                RequestHeader = headerHU,
                RequestItems = creditRequestService.ListItemByCreditId(huId),
                //StatusHistory = lstStatusHistory,
                AmountRequestText = TienBangChu(huAmount.ToString()), // tiền hoàn ứng
                TotalTURefer = tuAmount// tiền tạm ứng liên quan

            };


            return new ViewAsPdf(viewModel)
            {
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = 5, Bottom = 5, Right = 5, Top = 5 },
                //PageWidth = 300,
                // PageHeight = 1500,
                // CustomSwitches = "--disable-smart-shrinking"
            };
        }



        public async Task<IActionResult> PrintViewTU(long tuId)
        {
            string rootFolder = config["General:RootFolder"];

            var header = creditRequestService.GetCreditRequestById(tuId);
            decimal requestAmount = header.RequestedAmount.HasValue ? header.RequestedAmount.Value : 0;
            decimal approveAmount = header.ApprovedAmount.HasValue ? header.ApprovedAmount.Value : 0;
            //var lstStatusHistory = await commonService.GetListStatusHistory(tuId, "CreditRequest");


            

            var viewModel = new CreditPdfViewModel
            {
                RequestHeader = header,
                RequestItems = creditRequestService.ListItemByCreditId(tuId),
               // StatusHistory = lstStatusHistory,
                AmountRequestText = TienBangChu(requestAmount.ToString()),
                AmountApprovedText = TienBangChu(approveAmount.ToString())
            };




            return new ViewAsPdf(viewModel)
            {
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = 5, Bottom = 5, Right = 5, Top = 5 },
                //PageWidth = 300,
                // PageHeight = 1500,
                // CustomSwitches = "--disable-smart-shrinking"
            };
        }





        public string TienBangChu(string tien)
        {
            string totalFormat = tien.Replace(",", "");
            string totalDesc = Helper.NumToText(totalFormat);

            try
            {
                string firstRefix = totalDesc.Substring(0, 1).ToUpper();
                string lastRefix = totalDesc.Substring(1, totalDesc.Length - 1).ToLower();
                string resultTotalDec = firstRefix + lastRefix;
                return resultTotalDec;
            }
            catch (Exception ex)
            {
                return "0 đồng";
            }


        }





    }
}
