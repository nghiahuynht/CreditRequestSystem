using DAL.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class DashboardService: BaseService, IDashboardService
    {
        private EntityDataContext dtx;
        public DashboardService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }


       

    }
}
