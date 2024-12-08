﻿using DAL.IService;
using DAL.Models;
using DAL.Models.PaymentRequqest;
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




    }
}
