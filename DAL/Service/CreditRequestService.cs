using DAL.IService;
using DAL.Models;
using DAL.Models.CreditRequest;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class CreditRequestService : BaseService, ICreditRequestService
    {
        private EntityDataContext dtx;
        public CreditRequestService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }

        

        public  CreditRequestViewModel GetCreditRequestById(long id)
        {
            var res = new CreditRequestViewModel();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@Id",id),
                };
                ValidNullValue(param);
                res = dtx.CreditRequestViewModel.FromSql("EXEC sp_SearchCreditRequestById @Id", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return res;
        }


        public CreditRequestViewModel GetCreditRequestByCode(string code)
        {
            var res = new CreditRequestViewModel();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@Code",code),
                };
                ValidNullValue(param);
                res = dtx.CreditRequestViewModel.FromSql("EXEC sp_SearchCreditRequestByCode @Code", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return res;
        }




        public async Task<SaveResultModel<object>> SaveCreditRequest(CreditRequestViewModel model,string userLogin)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@CreaditType", model.CreaditType),
                    new SqlParameter("@DateRequest", model.DateRequest),
                    new SqlParameter("@UserRequest", model.UserRequest),
                    new SqlParameter("@RequestedAmount", model.RequestedAmount),
                    new SqlParameter("@ApprovedAmount", model.ApprovedAmount),
                    new SqlParameter("@RemainAmount", model.RemainAmount),
                    new SqlParameter("@Reason", model.Reason),
                    new SqlParameter("@UserName", userLogin),
                    new SqlParameter("@ReferRequestCode", model.ReferRequestCode),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdateCreditRequest @Id,@CreaditType,@DateRequest,@UserRequest,@RequestedAmount,@ApprovedAmount,@RemainAmount,@Reason,@UserName,@ReferRequestCode,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public DataTableResultModel<CreditRequestGridModel> SearchCreditRequestPaging(CreditRequestFilterModel filter, bool isExcel)
        {
            var res = new DataTableResultModel<CreditRequestGridModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@IsExcel", isExcel),
                    new SqlParameter("@Status", filter.Status),
                    new SqlParameter("@CreditType", filter.CreditType),
                    new SqlParameter("@FromDate", filter.FromDate),
                    new SqlParameter("@ToDate", filter.ToDate),
                    new SqlParameter("@Keyword", filter.ContentCredit),
                    new SqlParameter("@UserSearch", filter.UserName),
                    new SqlParameter("@PageCurrent", filter.start),
                    new SqlParameter("@PageSize", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.CreditRequestGridModel.FromSql("sp_SearchPaymentRequestPaging @IsExcel,@Status,@CreditType,@FromDate,@ToDate,@Keyword,@UserSearch,@PageCurrent,@PageSize,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt64(param[param.Length - 1].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<CreditRequestGridModel>();
            }

            return res;
        }



        public SaveResultModel<object> ChangeStatusRequestCredit(ChangeStatusRequestParamModel model)
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
                  new SqlParameter("@AmountApprove", model.amountApprove),
                  new SqlParameter("@RejectNote", model.rejectNote),
               };


                ValidNullValue(param);
                dtx.Database.ExecuteSqlCommand("EXEC sp_ChangeStatusRequestCredit @RequestId,@Status,@UserName,@AmountApprove,@RejectNote", param);

            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }




        //=========================== credit item ===================================


        public SaveResultModel<object> SaveCreditRequestItem(CreditRequestItemModel model)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                   new SqlParameter("@CreditRequestId", model.CreditRequestId),
                    new SqlParameter("@Name", model.Name),
                    new SqlParameter("@Unit", model.Unit),
                    new SqlParameter("@Quanti", model.Quanti),
                    new SqlParameter("@Price", model.Price),
                     new SqlParameter("@Note", model.Note),
               };


                ValidNullValue(param);
                dtx.Database.ExecuteSqlCommand("EXEC sp_SaveCreditRequestItem @Id,@CreditRequestId,@Name,@Unit,@Quanti,@Price,@Note", param);

            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public CreditRequestItemModel GetCreditRequestItemById(long id)
        {
            var res = new CreditRequestItemModel();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", id),
                };
                ValidNullValue(param);
                res = dtx.CreditRequestItemModel.FromSql("sp_GetRequestCreditItemById @Id", param).FirstOrDefault();

            }
            catch (Exception ex)
            {
                
            }

            return res;
        }

        public List<CreditRequestItemModel> ListItemByCreditId(long requestId)
        {
            var res = new List<CreditRequestItemModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@RequestId", requestId),
                };
                ValidNullValue(param);
                res = dtx.CreditRequestItemModel.FromSql("EXEC sp_GetRequestCreditItemByRequestId @RequestId", param).ToList();

            }
            catch (Exception ex)
            {

            }
            return res;
        }


        public SaveResultModel<object> DeleteItem(long itemId)
        {
            var res = new SaveResultModel<object>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@ItemId", itemId),
                };
                ValidNullValue(param);
                dtx.Database.ExecuteSqlCommand("EXEC sp_DeleteItemRequest @ItemId", param);

            }
            catch (Exception ex)
            {

            }
            return res;
        }


        //============= Get Matrix approve ============

        public CreditRequestMatrixModel GetMatrixApproveByUserCreate(string createdBy)
        {
            var res = new CreditRequestMatrixModel();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@CreatedBy", createdBy),
                };
                ValidNullValue(param);
                res = dtx.CreditRequestMatrixModel.FromSql("EXEC sp_GetRequestApproveMatrixByCreatedBy @CreatedBy", param).FirstOrDefault();
                res = res == null ? new CreditRequestMatrixModel() : res;
            }
            catch (Exception ex)
            {
                res = new CreditRequestMatrixModel();
            }

            return res;
        }






    }
}
