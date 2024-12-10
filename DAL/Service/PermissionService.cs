using DAL.IService;
using DAL.Models;
using DAL.Models.Permission;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class PermissionService: BaseService, IPermissionService
    {
        private EntityDataContext dtx;
        public PermissionService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }
       

        public async Task<SaveResultModel<object>> CreatePermissionInCharge(PermissionInChargeCreateModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@ProjectId", model.ProjectId),
                    new SqlParameter("@ProjectName", model.ProjectName),
                    new SqlParameter("@UserId", model.UserId),
                    new SqlParameter("@UserName", model.UserName),
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdatePermissionInCharge @Id,@ProjectId,@ProjectName,@UserId,@UserName,@ActionBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<bool> DeletePermissionProjectById(int Id)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id)

                };
                ValidNullValue(param);
               var rs= await dtx.Database.ExecuteSqlCommandAsync(@"EXEC DeletePermissionProjectById @Id", param);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<PermissionProjectViewModel>> GetPermissionProjectByUserId(int userId)
        {
            var res = new List<PermissionProjectViewModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@UserId",userId),
                    
                };
                ValidNullValue(param);
                 res = dtx.PermissionProjectViewModel.FromSql("sp_GetPermissionProjectByUserId @UserId", param).ToList();
               
                
            }
            catch (Exception ex)
            {
                
            }

            return res;
        }

        
    }
}
