using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
