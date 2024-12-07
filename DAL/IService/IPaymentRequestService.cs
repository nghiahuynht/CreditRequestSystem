using DAL.Models;
using DAL.Models.PaymentRequqest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface IPaymentRequestService
    {
        Task<SaveResultModel<object>> SavePaymentRequest(PaymentRequestModel model, string userLogin);
        Task<PaymentRequestModel> GetPaymentRequestHeaderById(long id);
        Task<List<PaymentRequestItemModel>> GetPaymentRequestItemsByRequestId(long requestId);
    }
}
