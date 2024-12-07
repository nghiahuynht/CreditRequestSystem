using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.IService;
using DAL.Models.PaymentRequqest;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PaymentRequestController : AppBaseController
    {
        private IPaymentRequestService paymentRequestService;
        private ICommonService commonService;

        public PaymentRequestController(IPaymentRequestService paymentRequestService, ICommonService commonService)
        {
            this.paymentRequestService = paymentRequestService;
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

            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<JsonResult> SavePaymentRequest([FromBody] RequestViewModel model)
        {
            var request = await paymentRequestService.SavePaymentRequest(model.RequestHeader,AuthenInfo().UserName);
            return Json(request);
        }


    }
}