﻿using DAL.Models;
using DAL.Models.Category;
using DAL.Models.ProjectFinancialDetail;
using DAL.Models.ProjectFinancialSummar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
   public interface IProjectFinancialDetailService
    {
        Task<SaveResultModel<object>> CreateProjectFinancialDetail(ProjectFinancialDetailAddModel model, string userName);
        SaveResultModel<object> ImportProjectFinancialDetail(ProjectPlaningImportModel model, string userName);
        Task<bool> DeleteProjectFinancialDetail(int Id, string userName);
        Task<ProjectFinancialDetailModel> GetProjectFinancialDetailById(int Id);
        Task<List<ProjectFinancialDetailModel>> GetAllProjectDetailByProjectId(int Id);
        Task<SaveResultModel<object>> CreateProfileForProjectDetail(PaymentInfoProjectDetailModel model, string userName);
        Task<List<PaymentInfoProjectDetailModel>> GetAllProfieForProjectId(int Id,int activeGroupId,int expenseId);
        Task<bool> DeletePaymentProfileOfProjectDetail(int ProjectDetailId, long ProfileId, string userName);

        DataTableResultModel<ProjectFinancialDetailTableModel> GetDataProjectFinancialDetailPaging(ProjectFinancialDetailFilterModel filter,int userId);

        Task<List<CategoryActiveGroupViewModel>> GetActiveGroupByProjectIdUserId(int Id,int userId);
    }
}
