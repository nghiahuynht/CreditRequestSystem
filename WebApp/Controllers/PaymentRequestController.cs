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

namespace WebApp.Controllers
{
    public class PaymentRequestController : AppBaseController
    {
        private IPaymentRequestService paymentRequestService;
        private IProjectFinancialSummarService projectFinancialSummarService;
        private IProjectFinancialDetailService projectFinancialDetailService;
        private ICategoryService categoryService;


        private ICommonService commonService;

        public PaymentRequestController(IPaymentRequestService paymentRequestService, IProjectFinancialSummarService projectFinancialSummarService
            , IProjectFinancialDetailService projectFinancialDetailService
            , ICategoryService categoryService
            , ICommonService commonService)
        {
            this.paymentRequestService = paymentRequestService;
            this.projectFinancialSummarService = projectFinancialSummarService;
            this.projectFinancialDetailService = projectFinancialDetailService;
            this.categoryService = categoryService;
            this.commonService = commonService;
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

            ViewBag.DDLProject = await paymentRequestService.GetProjectByUser(AuthenInfo().UserName);
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
            var lstActivity = await projectFinancialDetailService.GetAllProjectDetailByProjectId(projectId);
            return Json(lstActivity);
        }

        [HttpGet]
        public JsonResult GetExpenseByActivity(int activityId)
        {
            var lstExpense = categoryService.GetExpenseByActiveGroup(activityId);
            return Json(lstExpense);
        }

        [HttpGet]
        public PartialViewResult _PaymentRequestAttachment(int expenseId)
        {
            var mandatoryAttachRequest = categoryService.GetPaymentProfileByExpense(expenseId);
            return PartialView(mandatoryAttachRequest);
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

    }
}