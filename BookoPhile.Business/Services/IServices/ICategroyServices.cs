using BookoPhile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookoPhile.Business.Services.IServices
{
    public interface ICategroyServices
    {
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoryAsync(Category category);
    }
}
