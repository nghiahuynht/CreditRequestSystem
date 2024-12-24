using DAL.Entities;
using DAL.Models;
using DAL.Models.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface IUserInfoService
    {
        UserInfo Login(string userName,string pass);
        string GetRoleByUser(string userName);
        SaveResultModel<object> CreateNewUser(UserInfo entity, string userName);
        SaveResultModel<object> UpdateUser(UserInfo entity, string userName);
        List<ComboBoxModel> GetAllRoles();
        UserInfo GetUserById(int id);
        DataTableResultModel<UserInfoGridModel> SearchUserInfo(UserInfoFilterModel filter);
        Task<List<MenuRole>> GetMenuByRole(string roleCode);
        Task<List<Menu>> LstMenu();
        Task<List<Menu>> LstMenuNavigationByRole(int roleCode);
        Task<UserInfo> GetUserByUserName(string userName);
        Task<List<UserInfo>> SearchUserAutocomplete(string keyword);
        Task SavePermissionMenu(string roleCode, int MenuId);
        ListResultModel<ComboBoxModel> GetListUserByRoles(string roles);
        SaveResultModel<object> ChangePass(ChangePassModel model);
        List<UserInfoGridModel> GetAllUserByDepartment (int departmentId);
        Task<SaveResultModel<object>> CreatePermissionUser (PermissionUserModel model,string userName);

        Task<List<PermissionMenuModel>> GetPermissionMenuByUserId(int UserId);
        Task<List<PermissionMenuInfoModel>> GetPermissionByUserIdMenuId(int UserId,int MenuId);

        Task<bool> DeletePermissionByUserIdMenuId(int UserId, int MenuId);
        void CreateUserByImport(List<UserInfoImportModel> models, string userName);
        Task<SaveResultModel<Object>> CopyPermisionUser(string fromUser, string toUser);
    }
}
