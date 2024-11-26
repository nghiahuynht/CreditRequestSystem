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

        public List<CategoryPaymentProfileViewModel> LstAllCategoryPaymentProfile(int activeGroupId)
        {
            var res = new List<CategoryPaymentProfileViewModel>();
            try
            {
                var param = new SqlParameter[] {
                  new SqlParameter("@ActiveGroupId",activeGroupId),
                };
                ValidNullValue(param);
                res = dtx.CategoryPaymentProfileViewModel.FromSql("EXEC sp_GetAllCategoryPaymentProfileByActiveGroup @ActiveGroupId", param).ToList();
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
    }
}
