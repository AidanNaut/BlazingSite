using BlazingSite.Data.Classes;
using BlazingSite.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingSite.Data.PostSection
{
    public class PostService : IPostService
    {
        protected readonly BlazingSiteBlogDbContext _context;

        public PostService([NotNull] BlazingSiteBlogDbContext context)
        {
            _context = context;
        }
        public virtual async Task<IEnumerable<Post>> GetAllAsync(int? categoryID = null)
        {
            var query = _context.Set<Post>()
                .Include(post => post.PostsCategories)
                .ThenInclude(postCategory => postCategory.Category)
                .AsQueryable()
                .EnabledPosts();

            if (!categoryID.HasValue)
                return await query.ToListAsync();

            return await query.Where(
                post => post.PostsCategories.Any(
                    postCategory => postCategory.CategoryId == categoryID 
                 && !postCategory.Deleted.HasValue 
                 && postCategory.Category != null 
                 && postCategory.Category.Enabled 
                 && !postCategory.Category.Deleted.HasValue
                 )
                ).ToListAsync();
        }

        public virtual async Task<Post> GetAsync(int id)
        {
            return await _context.Set<Post>()
                .Include(post => post.PostsCategories)
                .ThenInclude(postCategory => postCategory.Category)
                .EnabledPosts()
                .FirstOrDefaultAsync(post => post.Id == id);
        }
    }
}
