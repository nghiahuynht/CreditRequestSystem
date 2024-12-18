using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.IService;
using DAL.Models.PaymentRequqest;
using Microsoft.AspNetCore.Mvc;
using DAL.Models.ProjectFinancialSummar;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApp.Controllers
{
    public class PaymentRequestController : AppBaseController
    {
        private IPaymentRequestService paymentRequestService;
        private IProjectFinancialSummarService projectFinancialSummarService;
        private IProjectFinancialDetailService projectFinancialDetailService;
        private ICategoryService categoryService;
        private IAttachFileService attachFileService;
        private IConfiguration config;

        private ICommonService commonService;

        public PaymentRequestController(IPaymentRequestService paymentRequestService, IProjectFinancialSummarService projectFinancialSummarService
            , IProjectFinancialDetailService projectFinancialDetailService
            , ICategoryService categoryService
            , ICommonService commonService
            , IAttachFileService attachFileService
            , IConfiguration config)
        {
            this.paymentRequestService = paymentRequestService;
            this.projectFinancialSummarService = projectFinancialSummarService;
            this.projectFinancialDetailService = projectFinancialDetailService;
            this.categoryService = categoryService;
            this.commonService = commonService;
            this.attachFileService = attachFileService;
            this.config = config;
        }

        public IActionResult SearchRequest()
        {
            return View();
        }

        public async Task<IActionResult> RequestDetail(long? id)
        {
            var viewModel = new RequestViewModel();
            if (id.HasValue)
            {
                viewModel.RequestHeader = await paymentRequestService.GetPaymentRequestHeaderById(id.Value);
                viewModel.ListRequestItems = await paymentRequestService.GetPaymentRequestItemsByRequestId(id.Value);
            }
            else
            {


                viewModel.RequestHeader.CreatedBy = AuthenInfo().UserName;
                viewModel.RequestHeader.CreatedByName = AuthenInfo().FullName;
                viewModel.RequestHeader.Status = Contanst.PaymentRequesStatus_Draft;
                var departmenList = await commonService.ListAllDepartment();
                var departmentUser = departmenList.Where(x => x.Id.ToString() == AuthenInfo().DepartmentId).FirstOrDefault();
                viewModel.RequestHeader.CreatedByDepartment = departmentUser != null ? departmentUser.Name : string.Empty;
                viewModel.ListRequestItems = new List<PaymentRequestItemModel>
                {
                    new PaymentRequestItemModel
                    {
                        Id=0,ProjectId=0,ActivityId=0,ExpenseId=0,Price=null,Quanti=null,Note=null,Total=null
                    }
                };
            }

            ViewBag.DDLProject = await paymentRequestService.GetProjectByUser(AuthenInfo().UserId);
            ViewBag.StatusHistory =await paymentRequestService.GetListStatusHistory("PaymentRequest", id.HasValue?id.Value:0);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<JsonResult> SavePaymentRequest([FromBody] RequestViewModel model)
        {
            var request = await paymentRequestService.SavePaymentRequest(model.RequestHeader,AuthenInfo().UserName);
            if (request.IsSuccess && request.LongValReturn != 0)
            {
                await paymentRequestService.SavePaymentRequestLineItems(request.LongValReturn,model.ListRequestItems);
            }
            return Json(request);
        }
        [HttpGet]
        public async Task<JsonResult> GetProjectById(int projectId)
        {
            var res = await projectFinancialSummarService.GetProjectById(projectId);
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> GetActivityByProject(int projectId)
        {
            var lstActivity = await projectFinancialDetailService.GetActiveGroupByProjectIdUserId(projectId,AuthenInfo().UserId);
            return Json(lstActivity);
        }

        [HttpGet]
        public JsonResult GetExpenseByActivity(int activityId)
        {
            var lstExpense = categoryService.GetExpenseByActiveGroup(activityId);
            return Json(lstExpense);
        }

        //[HttpGet]
        //public async Task<PartialViewResult> _PaymentRequestAttachment(long requestId)
        //{
        //    var mandatoryAttachRequest = await paymentRequestService.GetAttachmentByRequest(requestId);
        //    return PartialView(mandatoryAttachRequest);
        //}


        [HttpGet]
        public PartialViewResult _PaymentRequestApproveCheckist(long requestId,int projectId,int actityId, int expenseId)
        {

            var viewModel = new PaymentAttachCheckistModel();
            viewModel.LstAttachments = paymentRequestService.GetAttachmentByRequest(requestId, projectId, actityId, expenseId).Result.Results;
            viewModel.LstApproveChecklist = paymentRequestService.GetCheckListApproveStepByRequest(requestId).Result.Results;

            return PartialView(viewModel);
        }

        public async Task<IActionResult> SearchPaymentRequest()
        {
            var filter = new PaymentRequestFilterSearchModel {
                FromDate = Common.FirtDayOfMonth(),
                ToDate = DateTime.Now.ToString("dd/MM/yyyy")
            };

            ViewBag.DDLProject = await projectFinancialSummarService.LstAllProjectFinancialSummar();


            return View(filter);
        }


        [HttpPost]
        public DataTableResultModel<PaymenRequestGridModel> SearchPaymentRequestPaging(PaymentRequestFilterSearchModel filter)
        {
            var res = paymentRequestService.SearchPaymentRequest(filter,false,AuthenInfo().UserName);
            return res;
        }


        [HttpPost]
        public JsonResult ChangePaymentRequestStatus([FromBody] ChangeStatusRequestParamModel model)
        {
            model.userName = AuthenInfo().UserName;
            var res = paymentRequestService.ChangeStatusPaymentRequest(model);
            return Json(res);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UploadAttachForRequestPayment(IFormCollection formattact, IFormFile postedFile)
        {
            string rootFolder = config["General:RootFolder"];
            string domain = config["General:Domain"];

            var fName = postedFile.FileName;
            string paymentRequestId = formattact["paymentRequestId"];
            string profileSuggestId = formattact["profileSuggestId"];

            //======== Step 1: upload to folder ===========

            var folder = $"{rootFolder}\\upload\\payment-request\\{paymentRequestId}";
            string filePath = Path.Combine(folder, fName);
            string urlPath = $"{domain}/upload/payment-request/{paymentRequestId}/{fName}";


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
                Id = 0,
                ObjectId = Convert.ToInt64(paymentRequestId),
                ObjectType = "PaymentRequest",
                FileName = fName,
                FilePath = filePath,
                URLPath = urlPath,
                CreatedBy = AuthenInfo().UserName,
                SuggestId =Convert.ToInt64(profileSuggestId)

            };
            await attachFileService.SaveAttachment(attachFile);

            return RedirectToAction("RequestDetail", "PaymentRequest", new { id = Convert.ToInt64(paymentRequestId) });
        }

        





    }
}