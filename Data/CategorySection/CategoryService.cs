using BlazingSite.Data.Classes;
using BlazingSite.Data.Interfaces;
using BlazingSite.Data.PostSection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazingSite.Data.CategorySection
{
    public partial class CategoryService : ICategoryService
    {
        protected readonly BlazingSiteBlogDbContext _context;

        public CategoryService([NotNull] BlazingSiteBlogDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Category> GetAsync(int id)
        {
            return await _context.Set<Category>().EnabledCategories().FirstOrDefaultAsync(post => post.Id == id);
        }
    }
}
