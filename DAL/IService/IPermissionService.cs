using DAL.Models;
using DAL.Models.Permission;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface IPermissionService
    {
        DataTableResultModel<PermissionInChargeTableModel> GetDataPermissionInChargePaging(PermissionInChargeFilterModel filter);

        Task<SaveResultModel<object>> CreatePermissionInCharge(PermissionInChargeCreateModel model, string userName);
    }
}
