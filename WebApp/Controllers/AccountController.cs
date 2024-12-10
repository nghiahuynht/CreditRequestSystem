using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.IService;
using DAL.Models;
using DAL.Models.PermissionMenu;
using DAL.Models.UserInfo;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserInfoService userService;
        private ICategoryService categoryService;

        public AccountController(IUserInfoService userService, ICategoryService categoryService)
        {
            this.userService = userService;
            this.categoryService = categoryService;
        }

        #region Login 

        public IActionResult Login()
        {
            var model = new LoginModel {
                UserName = "admin",
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            string failedAlert = string.Empty;
            ClaimsIdentity identity = null;
            bool IsAuthenticated = false;
            if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                var userInfo = userService.Login(model.UserName, model.Password);
                
                if (userInfo != null)
                {
                    string roleName = userService.GetRoleByUser(userInfo.UserName);
                    string permission = "";
                    var dataPer = await userService.GetPermissionMenuByUserId(userInfo.Id);
                    foreach(var per in dataPer)
                    {
                        permission += ","+per.Permissions;  
                    };   
                    identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,model.UserName),
                        new Claim("FullName",userInfo.FullName),
                        new Claim("DepartmentId",userInfo.DepartmentId.HasValue?userInfo.DepartmentId.Value.ToString():"0"),
                        new Claim(ClaimTypes.Role,roleName),
                        new Claim("UserId",userInfo.Id.ToString()),
                        new Claim("Permission",permission)
                    },CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuthenticated = true;
                }
                else
                {
                    failedAlert = "Login not successfully";
                }
               
            }
            else
            {
                failedAlert =  "Login not successfully";
            }


            if (IsAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index","Home");
            }
            



            ViewBag.LoginFail = failedAlert;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

        #endregion

        #region User info
       // [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            UserParViewModel par = new UserParViewModel();
            var lstRoles = userService.GetAllRoles();
            var lstDepartment =categoryService.LstAllCategoryDepartment();
            par.LstRoles = lstRoles;
            par.LstDepartment = lstDepartment;
            return View(par);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public DataTableResultModel<UserInfoGridModel> SearchUserInfo (UserInfoFilterModel filter)
        {
            var res = userService.SearchUserInfo(filter);
            return res;
        }

       // [Authorize(Roles = "Admin")]
        public IActionResult Detail(int? id)
        {
            var viewModel = new UserDetailViewModel();
            
            if (id.HasValue)
            {
                viewModel.User = userService.GetUserById(id.Value);
                viewModel.RoleSelected = userService.GetRoleByUser(viewModel.User.UserName);
            }
            else
            {
                viewModel.User = new UserInfo();
                viewModel.User.IsActive = true;
            }
            viewModel.LstRoles = userService.GetAllRoles();
            return View(viewModel);
        }
        [HttpPost]
      //  [Authorize(Roles = "Admin")]
        public JsonResult SaveUserInfo([FromBody] UserDetailViewModel model)
        {
            var res = new SaveResultModel<object>();
            model.User.RoleCode = model.RoleSelected;
            model.User.DepartmentId = Int32.Parse(model.DepartmentSelected);
            if (model.User.Id == 0)
            {
                res = userService.CreateNewUser(model.User, User.Identity.Name);
            }
            else
            {
                res = userService.UpdateUser(model.User, User.Identity.Name);
            }
            return Json(res);
        }


        public IActionResult PermissionMenu()
        {
            var lstRoles = userService.GetAllRoles();
            return View(lstRoles);
        }
        public async Task<PartialViewResult> _PartialLstPermissionMenu(string roleCode)
        {

            var viewModel = new PermisionRoleMenuViewModel
            {
                LstMenu = await userService.LstMenu(),
                LstMenuRole = await userService.GetMenuByRole(roleCode)
            };
            return PartialView(viewModel);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public JsonResult UpdatePermissionMenu([FromBody] MenuRole model)
        {
            var res = userService.SavePermissionMenu(model.RoleCode,model.MenuId);
            return Json(res);
        }


        public IActionResult ChangePassword(string id)
        {
            var model = new ChangePassModel
            {
                UserName = id
            };
            return View(model);
        }


        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public JsonResult ChangePass([FromBody] ChangePassModel model)
        {
            var res = userService.ChangePass(model);
            return Json(res);
        }


        public IActionResult Add(int id=0)
        {
            var viewModel = new UserDetailViewModel();
            var lstDepartment = categoryService.LstAllCategoryDepartment();

            if (id >0)
            {
                viewModel.LstDepartment = lstDepartment;
                viewModel.User = userService.GetUserById(id);
                viewModel.RoleSelected = userService.GetRoleByUser(viewModel.User.UserName);
                viewModel.DepartmentSelected = viewModel.User.DepartmentId?.ToString();
            }
            else
            {
                viewModel.LstDepartment = lstDepartment;
                viewModel.User = new UserInfo();
                viewModel.User.IsActive = true;
            }
            viewModel.LstRoles = userService.GetAllRoles();
            return View(viewModel);
           
        }

        [HttpGet]
        public JsonResult  DeleteAccount(int Id)
        {
            try
            {
                var user = userService.GetUserById(Id);
                if (user!= null)
                {
                    user.IsActive = false;
                    user.UpdatedDate = DateTime.Now;
                    user.UpdatedBy= user.UserName;
                }
               var res = userService.UpdateUser(user, User.Identity.Name);
                return Json(new
                {
                    success = res.IsSuccess,
                    message = res.IsSuccess == true ? "Xóa thành công." : "Xóa thất bại"
                });

            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new
                {
                    success = false,
                    message = $"Đã xảy ra lỗi: {ex.Message}"
                });
            }
        }

        [HttpGet]
        public JsonResult GetUserByDepartment(int Id)
        {
            try
            {

                var rs = userService.GetAllUserByDepartment(Id);
                return Json(new
                {
                    isSuccess = true,
                    data = rs

                });

            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new
                {
                    success = false,
                    message = $"Đã xảy ra lỗi: {ex.Message}"
                });
            }
        }
        #endregion


        #region Permission
        public async Task<IActionResult> FormPermissonUser(int id = 0)
        {
            var viewModel = new PermissionUserParModel();
            var lstMenu = await userService.LstMenu();
            var lstPermssionMenu = await userService.GetPermissionMenuByUserId(id);
            lstMenu = lstMenu.FindAll(x => x.IsActive == true && x.Parent > 0 && x.IsActive == true);
            viewModel.LstMenu = lstMenu;
            viewModel.LstPermissionMenu = lstPermssionMenu;
            viewModel.UserId = id;
            return View(viewModel);

        }

        [HttpPost]
        public async Task<JsonResult> CreatePermissionUser([FromBody] PermissionUserModel model)
        {
            var res = new SaveResultModel<object>();
            // remove trước khi tạo
            var rsDelete = await userService.DeletePermissionByUserIdMenuId(model.UserId, model.MenuId);
            if(rsDelete == false)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Lỗi xóa permission trước khi lưu mới";
                return Json(res);
            }    
            res = await userService.CreatePermissionUser(model, User.Identity.Name);
            
            return Json(res);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetDetailPermission(int MenuId,int UserId)
        {
            

            var res = await userService.GetPermissionByUserIdMenuId(UserId, MenuId);
            
            return Json(res);
        }    
        
        [HttpGet]
        public async Task<JsonResult> DeletePermissionByUserIdMenuId(int MenuId,int UserId)
        {


            try
            {
                
                var res = await userService.DeletePermissionByUserIdMenuId(UserId, MenuId);
                return Json(new
                {
                    success = res,
                    message = res == true ? "Xóa thành công." : "Xóa thất bại"
                });

            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new
                {
                    success = false,
                    message = $"Đã xảy ra lỗi: {ex.Message}"
                });
            }
        }


        #endregion
    }
}