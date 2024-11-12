using DAL.Models;
using DAL.Models.CreditRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface ICreditRequestService
    {
        DataTableResultModel<CreditRequestGridModel> SearchCreditRequestPaging(CreditRequestFilterModel filter, bool isExcel);
        Task<SaveResultModel<object>> SaveCreditRequest(CreditRequestViewModel model, string userLogin);
        CreditRequestViewModel GetCreditRequestById(long id);
        CreditRequestViewModel GetCreditRequestByCode(string code);
        SaveResultModel<object> SaveCreditRequestItem(CreditRequestItemModel model);
        CreditRequestItemModel GetCreditRequestItemById(long id);
        List<CreditRequestItemModel> ListItemByCreditId(long requestId);
        SaveResultModel<object> DeleteItem(long itemId);
        SaveResultModel<object> ChangeStatusRequestCredit(ChangeStatusRequestParamModel model);

        CreditRequestMatrixModel GetMatrixApproveByUserCreate(string createdBy);
    }
}
