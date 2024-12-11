using DAL.IService;
using DAL.Models;
using DAL.Models.ProjectFinancialDetail;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class ProjectFinancialDetailService : BaseService, IProjectFinancialDetailService
    {
        private EntityDataContext dtx;
        public ProjectFinancialDetailService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }

        public async Task<SaveResultModel<object>> CreateProfileForProjectDetail(PaymentInfoProjectDetailModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@ProjectDetailId", model.ProjectDetailId),
                    new SqlParameter("@ActiveGroupId", model.ActiveGroupId),
                    new SqlParameter("@ExpenseId", model.ExpenseId),
                    new SqlParameter("@ProfileId", model.ProfileId),
                    new SqlParameter("@FileAttach", model.FileAttach),
                    new SqlParameter("@PaymentInfoCode", model.PaymentInfoCode),
                    new SqlParameter("@PaymentInfoName", model.PaymentInfoName),
                    new SqlParameter("@Notes", model.Notes),
                    new SqlParameter("@CreatedBy", userName),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertPaymentProfileForProjectDetail @ProjectDetailId,@ActiveGroupId,@ExpenseId,@ProfileId,@FileAttach,@PaymentInfoCode,@PaymentInfoName,@Notes,@CreatedBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<SaveResultModel<object>> CreateProjectFinancialDetail(ProjectFinancialDetailAddModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@ProjectId", model.ProjectId),
                    new SqlParameter("@ActivityGroupId", model.ActivityGroupId),
                    new SqlParameter("@ExpenseId", model.ExpenseId),
                    new SqlParameter("@Standard", model.Standard),
                    new SqlParameter("@Quantity", model.Quantity),
                    new SqlParameter("@Unit", ""),
                    new SqlParameter("@Price", model.Price),
                    new SqlParameter("@TotalAmount", model.TotalAmount),
                    new SqlParameter("@Notes", model.Notes),
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdateProjectFinancialDetail @Id,@ProjectId,@ActivityGroupId,@ExpenseId,@Standard,@Quantity,@Unit,@Price,@TotalAmount,@Notes,@ActionBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<bool> DeleteProjectFinancialDetail(int Id, string userName)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@ActionBy", userName),

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeleteProjectFinancialDetail @Id,@ActionBy", param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ProjectFinancialDetailModel>> GetAllProjectDetailByProjectId(int Id)
        {
            List<ProjectFinancialDetailModel> res = new List<ProjectFinancialDetailModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id)
                };
                ValidNullValue(param);

                res = await dtx.ProjectFinancialDetailModel.FromSql("EXEC sp_GetProjectFinancialDetailByProjectId @Id", param).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public async Task<ProjectFinancialDetailModel> GetProjectFinancialDetailById(int Id)
        {
            ProjectFinancialDetailModel res = new ProjectFinancialDetailModel();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id)
                };
                ValidNullValue(param);

                res = await dtx.ProjectFinancialDetailModel.FromSql("EXEC sp_GetProjectFinancialDetailById @Id", param).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public async Task<List<PaymentInfoProjectDetailModel>> GetAllProfieForProjectId(int Id)
        {
            List<PaymentInfoProjectDetailModel> res = new List<PaymentInfoProjectDetailModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id)
                };
                ValidNullValue(param);

                res = await dtx.PaymentInfoProjectDetailModel.FromSql("EXEC sp_GetAllProfieForProjectId @Id", param).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public async Task<bool> DeletePaymentProfileOfProjectDetail(int ProjectDetailId, long ProfileId, string userName)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@ProjectDetailId", ProjectDetailId),
                    new SqlParameter("@ProfileId", ProfileId),
                    new SqlParameter("@ActionBy", userName),

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeleteProjectDetailPaymentProfile @ProjectDetailId,@ProfileId,@ActionBy", param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  DataTableResultModel<ProjectFinancialDetailTableModel> GetDataProjectFinancialDetailPaging(ProjectFinancialDetailFilterModel filter,int userId)
        {
            var res = new DataTableResultModel<ProjectFinancialDetailTableModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@userId", userId),
                    new SqlParameter("@projectId", filter.ProjectId),
                    new SqlParameter("@activeGroupId", filter.ActiveGroupId),
                    new SqlParameter("@expenseId", filter.ExpenseId),
                    new SqlParameter("@Start", filter.start),
                    new SqlParameter("@Length", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.ProjectFinancialDetailTableModel.FromSql("sp_GetProjectDetailPaging @userId,@projectId,@activeGroupId,@expenseId,@Start,@Length,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt16(param[5].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<ProjectFinancialDetailTableModel>();
            }

            return res;
        }
    }
}
