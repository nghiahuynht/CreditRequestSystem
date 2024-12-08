using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.UserInfo
{
   public class PermissionUserParModel
    {
        public int UserId { get; set; }
        public List<Menu> LstMenu { get; set; }
        public List<PermissionMenuModel> LstPermissionMenu { get; set; }
    }

    public class PermissionUserModel
    {
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public string MenuPrefix { get; set; }
        public List<PermissionDetailModel> Permission { get; set; }
    } 
    public class PermissionMenuModel
    {
        public string Menu { get; set; }
        public int MenuId { get; set; }
        public string MenuPrefix { get; set; }
        public string PermissionNames { get; set; }
        public string Permissions { get; set; }

    }
    public class PermissionDetailModel
    {
        public string Permission { get; set; }
        public string PermissionName { get; set; }
    }
    public class PermissionMenuInfoModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public string Permission { get; set; }
        public string PermissionName { get; set; }
       
    }

}
