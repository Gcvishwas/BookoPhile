using BookoPhile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookoPhile.Business.Services.IServices
{
    public interface ICategoryServices
    {
        Task<Category?> GetCategoryByIdAsync(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> CreateCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);  

        Task<Category> DeleteCategoryAsync(int id);

        Task<bool> IsCategoryNameUniqueAsync(string name, int? categoryId=null)
    }
}
