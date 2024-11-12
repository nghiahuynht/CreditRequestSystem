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

       

    }
}
