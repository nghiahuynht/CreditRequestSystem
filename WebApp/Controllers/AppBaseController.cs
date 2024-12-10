using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AppBaseController : Controller
    {
      public AuthenticatedModel AuthenInfo()
      {
            var authen = new AuthenticatedModel();
            if (User.Identity.IsAuthenticated)
            {
                authen.UserName = User.Identity.Name;
                authen.FullName = User.Claims.FirstOrDefault(x => x.Type == "FullName").Value;
                authen.DepartmentId = User.Claims.FirstOrDefault(x => x.Type == "DepartmentId").Value;
                authen.Role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
                if (int.TryParse(userIdClaim, out int userId))
                {
                    authen.UserId = userId;
                }
                else
                {
                    // Handle the case where the conversion fails, if necessary
                    // For example, you can log an error or assign a default value
                    authen.UserId = -1; // Default value if the conversion fails
                }
            }
           
            return authen;
      }

      

    
    }
}