using DAL.Models;
using DAL.Models.ProjectFinancialSummar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface IProjectFinancialSummarService
    {
        Task<SaveResultModel<object>> CreateProjectFinancialSummar(ProjectFinancialSummarModel model, string userName);
        DataTableResultModel<ProjectFinancialSummarGridModel> SearchProjectFinancialSummar(ProjectFinancialSummarFilterModel filter);
        Task<ProjectFinancialSummarGridModel> GetProjectById(int Id);
        Task<bool> DeleteProjectFinancialSummar(int Id, string userName);
        Task<List<ProjectFinancialSummarDLLModel>> LstAllProjectFinancialSummar();
        Task<ProjectOverviewModel> GetProjectOverviewById(int Id);
        Task<SaveResultModel<object>> CheckCodeUnique(string prefix, string code);

    }
}
