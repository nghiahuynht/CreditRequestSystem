using DAL.Models.Category;
using DAL.Models.ProjectFinancialSummar;
using DAL.Models.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Permission
{
   public class PermissionInChargeParModel
    {
        public List<ProjectFinancialSummarDLLModel> LstProject { get; set; }
        public List<CategoryActiveGroupViewModel> LstActiveGroup { get; set; }

    }

    public class PermissionInChargeTableModel
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int ProjectDetailId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ActiveGroupId { get; set; }
        public string ActiveGroupName { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class PermissionInChargeInfoModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string TypePermission { get; set; }
        
    }

    public class PermissionInChargeModel
    {
        public PermissionInChargeInfoModel data { get; set; }
        public List<ProjectFinancialSummarDLLModel> LstProject { get; set; }
        public List<CategoryActiveGroupViewModel> DM_NhomHoatDong { get; set; }
    }

    public class PermissionInChargeFilterModel : DataTableDefaultParamModel
    {
        public int ProjectId { get; set; }
        public int ActiveGroupId { get; set; }
    }
    public class PermissionInChargeCreateModel
    {
        public int Id { get; set; }
        public int ProjecDetailId { get; set; }
        public string ProjectName { get; set; }
        public int UserIdId { get; set; }
        public string UserName { get; set; }
    }
}
