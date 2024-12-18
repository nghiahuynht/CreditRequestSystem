using DAL.IService;
using DAL.Models;
using DAL.Models.Category;
using DAL.Models.PaymentRequqest;
using DAL.Models.ProjectFinancialSummar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class PaymentRequestService:BaseService, IPaymentRequestService
    {
        private EntityDataContext dtx;
        public PaymentRequestService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }


        public async Task<SaveResultModel<object>> SavePaymentRequest(PaymentRequestModel model, string userLogin)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@DateRequest", model.DateRequest),
                    new SqlParameter("@CreatedByDepartment", model.CreatedByDepartment),
                    new SqlParameter("@UserName", userLogin),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_SavePaymentRequest @Id,@DateRequest,@CreatedByDepartment,@UserName,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }



        public async Task SavePaymentRequestLineItems(long requestHeaderId, List<PaymentRequestItemModel> model)
        {
            foreach (var item in model)
            {
                try
                {
                    var param = new SqlParameter[]
                       {
                        new SqlParameter("@Id", item.Id),
                        new SqlParameter("@RequestId", requestHeaderId),
                        new SqlParameter("@ProjectId", item.ProjectId),
                        new SqlParameter("@ActivityId", item.ActivityId),
                        new SqlParameter("@ExpenseId", item.ExpenseId),
                        new SqlParameter("@Price", item.Price),
                        new SqlParameter("@Quanti", item.Quanti),
                        new SqlParameter("@Note", item.Note),
                       };

                    ValidNullValue(param);
                    await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_SavePaymentRequestLineItem @Id,@RequestId,@ProjectId,@ActivityId,@ExpenseId,@Price,@Quanti,@Note", param);
                }
                catch
                {

                }
            }
            

        }




        public async Task<PaymentRequestModel> GetPaymentRequestHeaderById(long id)
        {
            var res = new PaymentRequestModel();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@RequestId",id),
                };
                ValidNullValue(param);
                res = await dtx.PaymentRequestModel.FromSql("EXEC sp_GetPaymentRequestById @RequestId", param).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

            }
            return res;
        }


        public async Task<List<PaymentRequestItemModel>> GetPaymentRequestItemsByRequestId(long requestId)
        {
            var res = new List<PaymentRequestItemModel>();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@RequestId",requestId),
                };
                ValidNullValue(param);
                res = await dtx.PaymentRequestItemModel.FromSql("EXEC sp_GetPaymentRequestLineItemsByRequestId @RequestId", param).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return res;
        }



        public async Task<ListResultModel<ProjectFinancialSummarGridModel>> GetProjectByUser(int userId)
        {
            var res = new ListResultModel<ProjectFinancialSummarGridModel>();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@UserId",userId),

                };
                ValidNullValue(param);
                res.Results = await dtx.ProjectFinancialSummarGridModel.FromSql("EXEC sp_GetProjectByUser @UserId", param).ToListAsync();
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.Results = new List<ProjectFinancialSummarGridModel>();
            }
            return res;
        }



        public DataTableResultModel<PaymenRequestGridModel> SearchPaymentRequest(PaymentRequestFilterSearchModel filter,bool isExcel,string userName)
        {
            var res = new DataTableResultModel<PaymenRequestGridModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@IsExcel", isExcel),
                    new SqlParameter("@ProjectId", filter.ProjectId),
                    new SqlParameter("@Activity", filter.ActivityId),
                    new SqlParameter("@FromDate", filter.FromDate),
                    new SqlParameter("@ToDate", filter.ToDate),
                    new SqlParameter("@Status", filter.Status),
                    new SqlParameter("@Keyword", filter.Keyword),
                    new SqlParameter("@UserSearch", userName),
                    new SqlParameter("@PageCurrent", filter.start),
                    new SqlParameter("@PageSize", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.PaymenRequestGridModel.FromSql("sp_SearchPaymentRequestPaging @IsExcel,@ProjectId,@Activity,@FromDate,@ToDate,@Status,@Keyword,@UserSearch,@PageCurrent,@PageSize,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt64(param[param.Length - 1].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<PaymenRequestGridModel>();
            }

            return res;
        }


        public SaveResultModel<object> ChangeStatusPaymentRequest(ChangeStatusRequestParamModel model)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@RequestId", model.requestId),
                  new SqlParameter("@Status", model.status),
                  new SqlParameter("@UserName", model.userName),
                  new SqlParameter("@Note", model.note),
               };


                ValidNullValue(param);
                dtx.Database.ExecuteSqlCommand("EXEC sp_ChangeStatusPaymentRequest @RequestId,@Status,@UserName,@Note", param);

            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }



        public async Task<ListResultModel<StatusHistoryModel>> GetListStatusHistory(string objectType, long objectId)
        {
            var res = new ListResultModel<StatusHistoryModel>();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@ObjectType",objectType),
                  new SqlParameter("@ObjectId",objectId),
                };
                ValidNullValue(param);
                res.Results = await dtx.StatusHistoryModel.FromSql("EXEC sp_GetHistoryStatus @ObjectType,@ObjectId", param).ToListAsync();
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        

        public async Task<ListResultModel<PaymentListAttachmentsModel>> GetAttachmentByRequest(long requestId, int projectId, int actityId, int expenseId)
        {
            var res = new ListResultModel<PaymentListAttachmentsModel>();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@RequestId",requestId),
                  new SqlParameter("@ProjectId",projectId),
                  new SqlParameter("@ActivityId",actityId),
                  new SqlParameter("@ExpenseId",expenseId),
                };
                ValidNullValue(param);
                res.Results = await dtx.PaymentListAttachmentsModel.FromSql("EXEC sp_GetAttachmentByRequestId @RequestId,@ProjectId,@ActivityId,@ExpenseId", param).ToListAsync();
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ListResultModel<PaymentCheckListHistoryModel>> GetCheckListApproveStepByRequest(long requestId)
        {
            var res = new ListResultModel<PaymentCheckListHistoryModel>();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@RequestId",requestId),
                };
                ValidNullValue(param);
                res.Results = await dtx.PaymentCheckListHistoryModel.FromSql("EXEC sp_GetApproveCheckListStepByRequest @RequestId", param).ToListAsync();
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
                res.Results = new List<PaymentCheckListHistoryModel>();
            }
            return res;
        }


    }
}
