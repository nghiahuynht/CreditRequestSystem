using DAL.Entities;
using DAL.IService;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class CommonService : BaseService, ICommonService
    {
        private EntityDataContext dtx;
        public CommonService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }

        public async Task<List<DepartmentModel>> ListAllDepartment()
        {
            var res = new List<DepartmentModel>();
            try
            {
                var param = new SqlParameter[] { };
                ValidNullValue(param);
                res = await dtx.DepartmentModel.FromSql("EXEC sp_ListAllDepartment", param).ToListAsync();

            }
            catch (Exception ex)
            {
                res = new List<DepartmentModel>();
            }
            return res;


        }

    }
}
