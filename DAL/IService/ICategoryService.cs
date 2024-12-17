using DAL.Entities;
using DAL.Models;
using DAL.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface ICategoryService
    {
        SaveResultModel<object> CreateCategory(Category category, string userName);
        SaveResultModel<object> UpdateCategory(Category category, string userName);
        Category GetCategoryById(int categoryId);
        List<Category> SearchCategory(string keyword);
        List<Category> LstAllCategoies();
        SaveResultModel<object> DeleteCategory(int categoryId, string userName);
        List<CategoryActiveGroupViewModel> LstAllCategoryActiveGroup();
        List<CategoryPaymentProfileViewModel> LstAllCategoryPaymentProfile();
        CategoryActiveGroupViewModel GetActiveGroupById(int Id);
        DataTableResultModel<CategoryActiveGroupViewModel> GetActiveGroupByFilter(CategoryFilterModel filter);
        Task<SaveResultModel<object>> CreateActiveGroup(CategoryActiveGroupViewModel model, string userName);
        Task<bool> DeleteActiveGroup(int categoryId, string userName);

        CategoryExpenseViewModel GetExpenseById(int Id);
        List<CategoryExpenseViewModel> LstAllCategoryExpense();
        DataTableResultModel<CategoryExpenseTableViewModel> GetExpenseByFilter(CategoryFilterModel filter);
        Task<SaveResultModel<object>> CreateExpense(CategoryExpenseViewModel model, string userName);
        Task<bool> DeleteExpense(int categoryId, string userName);
        DataTableResultModel<CategoryPaymentProfileViewModel> GetPaymentProfileByFilter(CategoryFilterModel filter);
        CategoryPaymentProfileViewModel GetPaymentProfileById(int Id);
        List<CategoryPaymentProfileViewModel> GetPaymentProfileByExpense(int expenseId);
        Task<SaveResultModel<object>> CreatePaymentProfile(CategoryPaymentInfoModel model, string userName);
        Task<SaveResultModel<object>> CreatePaymentProfileDetail(CategoryPaymentProfileDetailViewModel model, string userName);
        Task<bool> DeletePaymentProfile(int Id, string userName);

        List<CategoryDepartmentViewModel> LstAllCategoryDepartment();
        List<CategoryExpenseViewModel> GetExpenseByActiveGroup(int Id);
        List<CategoryActiveGroupViewModel> LstCategoryActiveGroupAllocationByProductId(int Id);

        List<CategoryPaymentProfileDetailViewModel> GetPaymentProfileDetailByPaymentProfileId(int Id);

        Task<bool> DeletePaymentProfileDetail(int Id);

        Task<SaveResultModel<object>> CreateExpensePaymentInfo(ExpensePaymentInfoModel model, string userName);
        Task<bool> DeleteExpensePaymentProfile(int Id);
        DataTableResultModel<CategoryDepartmentViewModel> GetDepartmentByFilter(CategoryFilterModel filter);

        CategoryDepartmentViewModel GetDepartmentById(int Id);

        Task<SaveResultModel<object>> CreateDepartment(CategoryDepartmentViewModel model, string userName);

        Task<bool> DeleteDepartment(int departmentId, string userName);
    }
}
