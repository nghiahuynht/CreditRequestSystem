using DAL.IService;
using DAL.Models;
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
                    new SqlParameter("@ProjectCode", model.ProjectCode),
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
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdateProjectFinancial @Id,@ProjectCode,@ProjectName,@LegalBasis,@ExecutionPeriod,@TotalAmount,@StatusText,@Notes,@ActionBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        

        public DataTableResultModel<ProjectFinancialSummarGridModel> SearchProjectFinancialSummar(ProjectFinancialSummarFilterModel filter)
        {
            var res = new DataTableResultModel<ProjectFinancialSummarGridModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@ProjectCode", filter.ProjectCode),
                    new SqlParameter("@ProjectName", filter.ProjectName),
                    new SqlParameter("@Start", filter.start),
                    new SqlParameter("@Length", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.ProjectFinancialSummarGridModel.FromSql("sp_GetProjectFinancialPaging @ProjectCode,@ProjectName,@Start,@Length,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt16(param[4].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<ProjectFinancialSummarGridModel>();
            }

            return res;
        }

        public async Task<ProjectFinancialSummarGridModel> GetProjectById(int Id)
        {
            var res = new ProjectFinancialSummarGridModel ();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@Id",Id),
                };
                ValidNullValue(param);
                res = await dtx.ProjectFinancialSummarGridModel.FromSql("EXEC sp_GetProjectFinancialById @Id", param).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public async Task<bool> DeleteProjectFinancialSummar(int Id, string userName)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@ActionBy", userName),

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeleteProjectFinancialSummar @Id,@ActionBy", param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ProjectFinancialSummarDLLModel>> LstAllProjectFinancialSummar()
        {
            var res = new List<ProjectFinancialSummarDLLModel>();
            try
            {

                res = await dtx.ProjectFinancialSummarDLLModel.FromSql("EXEC sp_GetAllProduct").ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return res;
        }
    }
}
