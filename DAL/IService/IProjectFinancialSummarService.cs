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
        
    }
}
