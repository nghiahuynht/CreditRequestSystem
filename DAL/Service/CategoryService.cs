using DAL.Entities;
using DAL.IService;
using DAL.Models;
using DAL.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class CategoryService: BaseService, ICategoryService
    {
        private EntityDataContext dtx;
        public CategoryService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }

        public List<Category> LstAllCategoies()
        {
            var lst = dtx.Category.Where(x => !x.IsDeleted).OrderBy(x => x.Name).ToList();
            return lst;
        }


        public SaveResultModel<object> CreateCategory(Category category, string userName)
        {
            var res = new SaveResultModel<object>();
            try
            {
                category.CreatedBy = userName;
                category.CreatedDate = DateTime.Now;
                category.IsActive = true;
                dtx.Category.Add(category);
                dtx.SaveChanges();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.ErrorMessage = ex.Message;
            }
            return res;

        }


        public SaveResultModel<object> UpdateCategory(Category category, string userName)
        {
            var res = new SaveResultModel<object>();
            try
            {
                category.UpdatedBy = userName;
                category.UpdatedDate = DateTime.Now;
                dtx.Category.Update(category);
                dtx.SaveChanges();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.ErrorMessage = ex.Message;
            }
            return res;

        }


        public Category GetCategoryById(int categoryId)
        {
            var res = dtx.Category.FirstOrDefault(x => x.Id == categoryId);
            return res;
        }

        public List<Category> SearchCategory(string keyword)
        {
            var res = new List<Category>();
            if (!string.IsNullOrEmpty(keyword))
            {
                res = dtx.Category.Where(x => x.Name.Contains(keyword) && !x.IsDeleted).OrderBy(x => x.Id).ToList();
            }
            else
            {
                res = dtx.Category.Where(x => !x.IsDeleted).OrderBy(x => x.Id).ToList();
            }
            return res;
        }

        public SaveResultModel<object> DeleteCategory(int categoryId, string userName)
        {
            var res = new SaveResultModel<object>();
            try
            {
                var cate = dtx.Category.FirstOrDefault(x => x.Id == categoryId);
                cate.IsDeleted = true;
                cate.UpdatedBy = userName;
                cate.UpdatedDate = DateTime.Now;
                dtx.Category.Update(cate);
                dtx.SaveChanges();

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.ErrorMessage = ex.Message;
            }
            return res;




        }

        public List<CategoryActiveGroupViewModel> LstAllCategoryActiveGroup()
        {
            var res = new List<CategoryActiveGroupViewModel>();
            try
            {
                
                res = dtx.CategoryActiveGroupViewModel.FromSql("EXEC sp_GetAllCategoryActiveGroup").ToList();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public List<CategoryPaymentProfileViewModel> LstAllCategoryPaymentProfile()
        {
            var res = new List<CategoryPaymentProfileViewModel>();
            try
            {
                
                res = dtx.CategoryPaymentProfileViewModel.FromSql("EXEC sp_GetAllCategoryPaymentProfile").ToList();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public CategoryActiveGroupViewModel GetActiveGroupById(int Id)
        {
            var res = new CategoryActiveGroupViewModel();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@Id",Id),
                };
                ValidNullValue(param);
                res = dtx.CategoryActiveGroupViewModel.FromSql("EXEC sp_GetActiveGroupById @Id", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public DataTableResultModel<CategoryActiveGroupViewModel> GetActiveGroupByFilter(CategoryFilterModel filter)
        {
            var res = new DataTableResultModel<CategoryActiveGroupViewModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Ma", filter.Code),
                    new SqlParameter("@Ten", filter.Name),
                    new SqlParameter("@Start", filter.start),
                    new SqlParameter("@Length", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.CategoryActiveGroupViewModel.FromSql("sp_GetActiveGroupPaging @Ma,@Ten,@Start,@Length,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt16(param[4].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<CategoryActiveGroupViewModel>();
            }

            return res;
        }

        public async Task<SaveResultModel<object>> CreateActiveGroup(CategoryActiveGroupViewModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@Code", model.Code),
                    new SqlParameter("@Name", model.Name),
                    new SqlParameter("@Notes", model.Notes),
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdateActiveGroup @Id,@Code,@Name,@Notes,@ActionBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<bool> DeleteActiveGroup(int Id, string userName)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@ActionBy", userName),

                };
                ValidNullValue(param);
               var rs= await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeleteActiveGroup @Id,@ActionBy", param);
                return rs>0? true:false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CategoryExpenseViewModel GetExpenseById(int Id)
        {
            var res = new CategoryExpenseViewModel();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@Id",Id),
                };
                ValidNullValue(param);
                res = dtx.CategoryExpenseViewModel.FromSql("EXEC sp_GetExpenseById @Id", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public DataTableResultModel<CategoryExpenseTableViewModel> GetExpenseByFilter(CategoryFilterModel filter)
        {
            var res = new DataTableResultModel<CategoryExpenseTableViewModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Ma", filter.Code),
                    new SqlParameter("@Ten", filter.Name),
                    new SqlParameter("@Start", filter.start),
                    new SqlParameter("@Length", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.CategoryExpenseTableViewModel.FromSql("sp_GetExpensePaging @Ma,@Ten,@Start,@Length,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt16(param[4].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<CategoryExpenseTableViewModel>();
            }

            return res;
        }

        public async Task<SaveResultModel<object>> CreateExpense(CategoryExpenseViewModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                  new SqlParameter("@ActiveGroupId", model.ActiveGroupId),
                    new SqlParameter("@Code", model.Code),
                    new SqlParameter("@Name", model.Name),
                    new SqlParameter("@Notes", model.Notes),
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdateExpense @Id,@ActiveGroupId,@Code,@Name,@Notes,@ActionBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<bool> DeleteExpense(int Id, string userName)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@ActionBy", userName),

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeleteExpense @Id,@ActionBy", param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  List<CategoryPaymentProfileViewModel> GetPaymentProfileByExpense(int expenseId)
        {
            var res = new List<CategoryPaymentProfileViewModel>();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@ExpenseId",expenseId),
                };
                ValidNullValue(param);
                res = dtx.CategoryPaymentProfileViewModel.FromSql("EXEC sp_GetAllCategoryPaymentProfileByExpense @ExpenseId", param).ToList();
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public DataTableResultModel<CategoryPaymentProfileViewModel> GetPaymentProfileByFilter(CategoryFilterModel filter)
        {
            var res = new DataTableResultModel<CategoryPaymentProfileViewModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Ma", filter.Code),
                    new SqlParameter("@Ten", filter.Name),
                    new SqlParameter("@Start", filter.start),
                    new SqlParameter("@Length", filter.length),
                    new SqlParameter { ParameterName = "@TotalRow", DbType = System.Data.DbType.Int16, Direction = System.Data.ParameterDirection.Output }
                };
                ValidNullValue(param);
                var lstData = dtx.CategoryPaymentProfileViewModel.FromSql("sp_GetPaymentProfilePaging @Ma,@Ten,@Start,@Length,@TotalRow OUT", param).ToList();
                res.recordsTotal = Convert.ToInt16(param[4].Value);
                res.recordsFiltered = res.recordsTotal;
                res.data = lstData.ToList();
            }
            catch (Exception ex)
            {
                res.recordsTotal = 0;
                res.recordsFiltered = 0;
                res.data = new List<CategoryPaymentProfileViewModel>();
            }

            return res;
        }

        public CategoryPaymentProfileViewModel GetPaymentProfileById(int Id)
        {
            var res = new CategoryPaymentProfileViewModel();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@Id",Id),
                };
                ValidNullValue(param);
                res = dtx.CategoryPaymentProfileViewModel.FromSql("EXEC sp_GetPaymentProfileById @Id", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public async Task<SaveResultModel<object>> CreatePaymentProfile(CategoryPaymentInfoModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@Code", model.PaymentInfoCode),
                    new SqlParameter("@Name", model.PaymentInfoName),
                    new SqlParameter("@Notes", model.Notes),
                    new SqlParameter("@FileAttachId", model.FileAttachId),   
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter("@IsRequiredDoc", model.IsRequiredDoc),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdatePaymentProfile @Id,@Code,@Name,@Notes,@FileAttachId,@ActionBy,@IsRequiredDoc,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<bool> DeletePaymentProfile(int Id, string userName)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@ActionBy", userName),

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeletePaymentProfile @Id,@ActionBy", param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CategoryExpenseViewModel> LstAllCategoryExpense()
        {
            var res = new List<CategoryExpenseViewModel>();
            try
            {

                res = dtx.CategoryExpenseViewModel.FromSql("EXEC sp_GetAllCategoryExpense").ToList();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public List<CategoryDepartmentViewModel> LstAllCategoryDepartment()
        {
            var res = new List<CategoryDepartmentViewModel>();
            try
            {

                res = dtx.CategoryDepartmentViewModel.FromSql("EXEC sp_GetAllCategoryDepartment").ToList();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public List<CategoryExpenseViewModel> GetExpenseByActiveGroup(int Id)
        {
            var res = new List<CategoryExpenseViewModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id)

                };
                ValidNullValue(param);
                res = dtx.CategoryExpenseViewModel.FromSql("EXEC sp_GetExpenseByActiveGroup @Id",param).ToList();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public List<CategoryActiveGroupViewModel> LstCategoryActiveGroupAllocationByProductId(int Id)
        {
            var res = new List<CategoryActiveGroupViewModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id)

                };
                ValidNullValue(param);
                res = dtx.CategoryActiveGroupViewModel.FromSql("EXEC sp_GetCategoryActiveGroupAllocationByProductId @Id",param).ToList();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public  List<CategoryPaymentProfileDetailViewModel> GetPaymentProfileDetailByPaymentProfileId(int Id)
        {
            var res = new List<CategoryPaymentProfileDetailViewModel>();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@Id",Id),
                };
                ValidNullValue(param);
                res = dtx.CategoryPaymentProfileDetailViewModel.FromSql("EXEC sp_GetPaymentProfileDetailByPaymentProfileId @Id", param).ToList();
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public async Task<bool> DeletePaymentProfileDetail(int Id)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id)

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeletePaymentProfileDetailById @Id", param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<SaveResultModel<object>> CreatePaymentProfileDetail(CategoryPaymentProfileDetailViewModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@PaymentProfileId", model.PaymentProfileId),
                    new SqlParameter("@Name", model.Name),
                    new SqlParameter("@Notes", model.Notes),
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdatePaymentProfileDetail @Id,@PaymentProfileId,@Name,@Notes,@ActionBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<SaveResultModel<object>> CreateExpensePaymentInfo(ExpensePaymentInfoModel model, string userName)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[]
               {
                  new SqlParameter("@Id", model.Id),
                    new SqlParameter("@ExpenseId", model.ExpenseId),
                    new SqlParameter("@ProfileId", model.ProfileId),
                    new SqlParameter("@PaymentInfoCode", model.PaymentInfoCode),
                    new SqlParameter("@PaymentInfoName", model.PaymentInfoName),
                    new SqlParameter("@Notes", model.Notes),
                    new SqlParameter("@ActionBy", userName),
                    new SqlParameter("@FileAttach", model.FileAttach),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

               };



                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync("EXEC sp_InsertUpdateExpensePaymentProfile @Id,@ExpenseId,@ProfileId,@PaymentInfoCode,@PaymentInfoName,@Notes,@ActionBy,@FileAttach,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);
            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<bool> DeleteExpensePaymentProfile(int Id)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", Id)

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeleteExpensePaymentProfile @Id", param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
