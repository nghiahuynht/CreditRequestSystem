﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.IService;
using DAL.Models;
using DAL.Models.PermissionMenu;
using DAL.Models.UserInfo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserInfoService userService;

        public AccountController(IUserInfoService userService)
        {
            this.userService = userService;
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
        public IActionResult Login(LoginModel model)
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
                    identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,model.UserName),
                        new Claim("FullName",userInfo.FullName),
                        new Claim(ClaimTypes.Role,roleName)
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
            var lstRoles = userService.GetAllRoles();
            return View(lstRoles);
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

            if (id >0)
            {
                viewModel.User = userService.GetUserById(id);
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
        #endregion

    }
}