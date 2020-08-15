using BlazingSite.Data.PostSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingSite.Data.Interfaces
{
    public partial interface ICategoryService
    {
        Task<Category> GetAsync(int id);

        Task<IEnumerable<Category>> GetAllAsync();
    }
}
