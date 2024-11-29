using DAL.Entities;
using DAL.Models;
using DAL.Models.Category;
using DAL.Models.CreditRequest;
using DAL.Models.ProjectFinancialDetail;
using DAL.Models.ProjectFinancialSummar;
using DAL.Models.UserInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class EntityDataContext : DbContext
    {
        public EntityDataContext(DbContextOptions<EntityDataContext> options) : base(options)
        {

        }

        /*============ SQL table ======================================*/

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuRole> MenuRole { get; set; }
       
        public DbSet<Unit> Unit { get; set; }
       
      
        /*============ for Excute SQL query=============================== */

        public DbSet<UserInfoGridModel> UserInfoGridModel  { get; set; }
       
        public DbSet<ComboBoxModel> ComboBoxModel { get; set; }
      

        public DbSet<CreditRequestGridModel> CreditRequestGridModel { get; set; }
        public DbSet<CreditRequestViewModel> CreditRequestViewModel { get; set; }

        public DbSet<CreditRequestItemModel> CreditRequestItemModel { get; set; }


        public DbSet<AttactFileModel> AttactFileModel { get; set; }

        public DbSet<CreditRequestMatrixModel> CreditRequestMatrixModel { get; set; }

        public DbSet<CategoryActiveGroupViewModel> CategoryActiveGroupViewModel { get; set; }
        public DbSet<CategoryPaymentProfileViewModel> CategoryPaymentProfileViewModel { get; set; }
        public DbSet<ProjectFinancialDetailModel> ProjectFinancialDetailModel { get; set; }
        public DbSet<ProjectFinancialSummarGridModel> ProjectFinancialSummarGridModel { get; set; }
        public DbSet<PaymentInfoProjectDetailModel> PaymentInfoProjectDetailModel { get; set; }
        public DbSet<CategoryExpenseViewModel> CategoryExpenseViewModel { get; set; }
        public DbSet<ProjectFinancialSummarDLLModel> ProjectFinancialSummarDLLModel { get; set; }
        public DbSet<ProjectFinancialDetailTableModel> ProjectFinancialDetailTableModel { get; set; }
        public DbSet<CategoryDepartmentViewModel> CategoryDepartmentViewModel { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComboBoxModel>().HasKey(o => o.Value);
            modelBuilder.Entity<RoleInfo>().HasKey(o => o.Code);
            modelBuilder.Entity<Unit>().HasKey(o => o.Code);
        }



    }
}
