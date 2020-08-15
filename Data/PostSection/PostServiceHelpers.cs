using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingSite.Data.PostSection
{
    public static class PostServiceHelpers
    {
        public static IQueryable<Post> EnabledPosts(this IQueryable<Post> query)
        {
            return query.Where(post => post.Enabled && post.Published.HasValue && !post.Deleted.HasValue);
        }
    }
}
