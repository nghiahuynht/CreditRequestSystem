using DAL.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.UserInfo
{
    public class UserDetailViewModel
    {
        public UserDetailViewModel()
        {
            User = new Entities.UserInfo();
            LstRoles = new List<ComboBoxModel>();
        }
        public DAL.Entities.UserInfo User { get; set; }
        public List<ComboBoxModel> LstRoles { get; set; }
        public List<CategoryDepartmentViewModel> LstDepartment { get; set; }
        public string RoleSelected { get; set; }
        public string DepartmentSelected { get; set; }
    }

    public class UserParViewModel
    {
        public List<ComboBoxModel> LstRoles { get; set; }
        public List<CategoryDepartmentViewModel> LstDepartment{ get; set; }
    }
}
