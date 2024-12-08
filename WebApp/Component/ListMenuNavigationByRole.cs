using DAL.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Component
{
    public class ListMenuNavigationByRole: ViewComponent
    {
        private IUserInfoService userService;

        public ListMenuNavigationByRole(IUserInfoService userService)
        {
            this.userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string UserId)
        {
            var lstMenu = await userService.LstMenuNavigationByRole(Int32.Parse(UserId));
            return await Task.FromResult((IViewComponentResult)View("LeftMenuNavigation", lstMenu));
        }


    }
}
