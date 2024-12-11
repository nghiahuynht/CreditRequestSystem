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
        Task<List<PermissionProjectViewModel>> GetPermissionProjectByUserId(int userId);

        Task<SaveResultModel<object>> CreatePermissionInCharge(PermissionInChargeCreateModel model, string userName);

        Task<bool> DeletePermissionProjectById(int Id);

        Task<SaveResultModel<object>> CreatePermissionCreateRequest(CreatePermissionCreateRequestModel model, string userName);

        Task<List<PermissionCreateRequestViewModel>> GetPermissionCreateRequestByUserId(int userId);
    }
}
