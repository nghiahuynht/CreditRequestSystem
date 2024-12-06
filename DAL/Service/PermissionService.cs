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
                    new SqlParameter("@ProjectDetailId", model.ProjecDetailId),
                    new SqlParameter("@ProjectName", model.ProjectName),
                    new SqlParameter("@UserId", model.UserIdId),
                    new SqlParameter("@UserName", model.UserName),
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdatePermissionInCharge @Id,@ProjectDetailId,@ProjectName,@UserId,@UserName,@ActionBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public DataTableResultModel<PermissionInChargeTableModel> GetDataPermissionInChargePaging(PermissionInChargeFilterModel filter)
        {
            var res = new DataTableResultModel<PermissionInChargeTableModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@projectId", filter.ProjectId),
                    new SqlParameter("@activeGroupId", filter.ActiveGroupId),
                    new SqlParameter("@Start", filter.start),
                    new SqlParameter("@Length", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.PermissionInChargeTableModel.FromSql("sp_GetDataPermisonInChargePaging @projectId,@activeGroupId,@Start,@Length,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt16(param[4].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<PermissionInChargeTableModel>();
            }

            return res;
        }

        
    }
}
