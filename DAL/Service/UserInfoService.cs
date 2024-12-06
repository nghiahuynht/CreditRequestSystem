using DAL.Entities;
using DAL.IService;
using DAL.Models;
using DAL.Models.UserInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class UserInfoService :BaseService, IUserInfoService
    {
        private EntityDataContext dtx;
        public UserInfoService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }
        public UserInfo Login(string userName, string pass)
        {
            var user = dtx.UserInfo.FirstOrDefault(x => (x.Email == userName.Trim() || x.UserName == userName.Trim()) && x.Pass == pass && x.IsActive);
            return user;
        }
        public string GetRoleByUser(string userName)
        {
            var user = dtx.UserInfo.FirstOrDefault(x => x.UserName == userName);
            return user != null ? user.RoleCode : string.Empty;
        }

        public SaveResultModel<object> CreateNewUser(UserInfo entity, string userName)
        {
            var saveModel = new SaveResultModel<object>();
            try
            {
                entity.CreatedBy = userName;
                entity.CreatedDate = DateTime.Now;
                entity.Pass = "123";
                dtx.UserInfo.Add(entity);

                dtx.SaveChanges();
                saveModel.ValueReturn = entity.Id;
                saveModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                saveModel.ErrorMessage = ex.Message;
            }


            return saveModel;
        }
        public SaveResultModel<object> UpdateUser(UserInfo entity, string userName)
        {
            var saveModel = new SaveResultModel<object>();
            try
            {
                var currentUser = dtx.UserInfo.FirstOrDefault(x => x.Id == entity.Id);

                currentUser.Phone = entity.Phone;
                currentUser.Email = entity.Email;
                currentUser.Title = entity.Title;
                currentUser.FullName = entity.FullName;
                currentUser.RoleCode = entity.RoleCode;
                currentUser.IsActive = entity.IsActive;
                currentUser.DepartmentId = entity.DepartmentId;
                currentUser.UpdatedBy = userName;
                currentUser.UpdatedDate = DateTime.Now;

                dtx.UserInfo.Update(currentUser);
                dtx.SaveChanges();
                saveModel.ValueReturn = entity.Id;
                saveModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                saveModel.ErrorMessage = ex.Message;
            }
            return saveModel;
        }

        public List<ComboBoxModel> GetAllRoles()
        {
            var lst = dtx.RoleInfo.OrderBy(x => x.Code).Select(x => new ComboBoxModel
            {
                Value = x.Code,
                Text = x.Name
            }).ToList();
            return lst;
        }

        public UserInfo GetUserById(int id)
        {
            var user = dtx.UserInfo.FirstOrDefault(x => x.Id == id);
            return user;
        }



        public DataTableResultModel<UserInfoGridModel> SearchUserInfo(UserInfoFilterModel filter)
        {
            var res = new DataTableResultModel<UserInfoGridModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@RoleCode", filter.RoleCode),
                    new SqlParameter("@Keyword", filter.Keyword),
                    new SqlParameter("@Start", filter.start),
                    new SqlParameter("@Length", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.UserInfoGridModel.FromSql("sp_SearchUserInfo @RoleCode,@Keyword,@Start,@Length,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt16(param[4].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<UserInfoGridModel>();
            }

            return res;
        }


        public async Task<List<MenuRole>> GetMenuByRole(string roleCode)
        {
            var lstMenuRole = await dtx.MenuRole.Where(x => x.RoleCode == roleCode).ToListAsync();
            return lstMenuRole;
        }

        public async Task<List<Menu>> LstMenu()
        {
            var lstMenuRole = await dtx.Menu.Where(x => x.IsActive).OrderBy(x => x.Priority).ToListAsync();
            return lstMenuRole;
        }


        public async Task<List<Menu>> LstMenuNavigationByRole(string roleCode)
        {
            var res = await (from menu in dtx.Menu
                             join menurole in dtx.MenuRole on menu.Id equals menurole.MenuId
                             where menurole.RoleCode == roleCode && menu.IsActive
                             select new Menu
                             {
                                 Id = menu.Id,
                                 Name = menu.Name,
                                 MenuIcon = menu.MenuIcon,
                                 URL = menu.URL,
                                 Priority = menu.Priority,
                                 Parent = menu.Parent
                             }).ToListAsync();
            return res;

        }


        public async Task<UserInfo> GetUserByUserName(string userName)
        {
            var user = await dtx.UserInfo.FirstOrDefaultAsync(x => x.UserName == userName);
            return user;
        }

       



        public async Task<List<UserInfo>> SearchUserAutocomplete(string keyword)
        {
            var user = await dtx.UserInfo.Where(x => x.IsActive && (x.UserName.Contains(keyword) || x.FullName.Contains(keyword))).ToListAsync();
            return user;
        }


        public async Task SavePermissionMenu(string roleCode, int MenuId)
        {
            
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@RoleCode", roleCode),
                    new SqlParameter("@MenuId", MenuId),

                };
                ValidNullValue(param);

               await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_SavePermissionMenu @RoleCode,@MenuId", param);

            }
            catch (Exception ex)
            {
               
            }
     


        }


        public ListResultModel<ComboBoxModel> GetListUserByRoles(string roles)// format: Admin,Sale
        {
            var res = new ListResultModel<ComboBoxModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@RoleCodes", roles)
                };
                ValidNullValue(param);
                res.Results = dtx.ComboBoxModel.FromSql("EXEC sp_GetUserByRole @RoleCodes", param).ToList();
  
            }catch(Exception ex)
            {
                res.IsSuccess = false;
                res.ErrorMessage = ex.Message;
            }
            return res;
        }

        public SaveResultModel<object> ChangePass(ChangePassModel model)
        {
            var res = new SaveResultModel<object>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@UserName", model.UserName),
                    new SqlParameter("@CurrentPass", model.CurrentPass),
                    new SqlParameter("@NewPass", model.NewPass),
                    new SqlParameter { ParameterName = "@ResId", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }

                };
                ValidNullValue(param);

                dtx.Database.ExecuteSqlCommand(@"EXEC sp_ChangePass @UserName,@CurrentPass,@NewPass,@ResId OUT", param);

                res.LongValReturn = Convert.ToInt16(param[param.Length -1].Value);
                if (res.LongValReturn == 0)
                {
                    res.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }
            return res;
        }

        public List<UserInfoGridModel> GetAllUserByDepartment(int departmentId)
        {
            var res = new List<UserInfoGridModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@DepartmentId", departmentId)
                };
                ValidNullValue(param);
                res = dtx.UserInfoGridModel.FromSql("EXEC sp_GetAllUserByDepartment @DepartmentId", param).ToList();

            }
            catch (Exception ex)
            {
                
            }
            return res;
        }
    }
}
