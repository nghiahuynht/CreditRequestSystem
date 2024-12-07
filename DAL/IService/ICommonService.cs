using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface ICommonService
    {
        Task<List<DepartmentModel>> ListAllDepartment();
    }
}
