using DAL.IService;
using DAL.Models;
using DAL.Models.ProjectFinancialSummar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class ProjectFinancialSummarService : BaseService, IProjectFinancialSummarService
    {
        private EntityDataContext dtx;
        public ProjectFinancialSummarService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }
        public async Task<SaveResultModel<object>> CreateProjectFinancialSummar(ProjectFinancialSummarModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@ProjectName", model.ProjectName),
                    new SqlParameter("@LegalBasis", model.LegalBasis),
                    new SqlParameter("@ExecutionPeriod", model.ExecutionPeriod),
                    new SqlParameter("@TotalAmount", model.TotalAmount),
                    new SqlParameter("@StatusText", model.StatusText),
                    new SqlParameter("@Notes", model.Notes),
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdateProjectFinancial @Id,@ProjectName,@LegalBasis,@ExecutionPeriod,@TotalAmount,@StatusText,@Notes,@ActionBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }
    }
}
