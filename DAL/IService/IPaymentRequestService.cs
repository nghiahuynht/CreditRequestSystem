﻿using DAL.Models;
using DAL.Models.Category;
using DAL.Models.PaymentRequqest;
using DAL.Models.ProjectFinancialSummar;
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
        Task<ListResultModel<ProjectFinancialSummarGridModel>> GetProjectByUser(int userId);
        Task SavePaymentRequestLineItems(long requestHeaderId, List<PaymentRequestItemModel> model);
        DataTableResultModel<PaymenRequestGridModel> SearchPaymentRequest(PaymentRequestFilterSearchModel filter, bool isExcel, string userName);
        SaveResultModel<object> ChangeStatusPaymentRequest(ChangeStatusRequestParamModel model);
        Task<ListResultModel<StatusHistoryModel>> GetListStatusHistory(string objectType, long objectId);
        Task<ListResultModel<PaymentListAttachmentsModel>> GetAttachmentByRequest(long requestId, int projectId, int actityId, int expenseId);
        Task<ListResultModel<PaymentCheckListHistoryModel>> GetCheckListApproveStepByRequest(long requestId);
        SaveResultModel<object> ApproveStepChecklist(PaymentRequestApproveStepModel model, string userName);
    }
}
