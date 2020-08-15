using BlazingSite.Data.PostSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlazingSite.Data.CategorySection
{
    public static class CategoryServiceHelpers
    {
        public static IQueryable<Category> EnabledCategories(this IQueryable<Category> query)
        {
            return query.Where(category => category.Enabled && !category.Deleted.HasValue);
        }
    }
}
