using BookoPhile.Business.Services.IServices;
using BookoPhile.Data;
using BookoPhile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BookoPhile.Business.Services
{
    public class CategoryService : ICategoryServices
    {

        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        } 
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
           var category=await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($" Category with id {id} not found.");    
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            
        }



        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            
        }

        public async Task<bool> IsCategoryNameUniqueAsync(string name, int? categoryId = null)
        {
            if (categoryId.HasValue)
            {
               return !await _context.Categories.AnyAsync(c=>c.Name.ToLower()==name.ToLower() && c.Id!=categoryId.Value)
            }
        }
    }
}
