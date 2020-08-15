using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingSite.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazingSite.Data.Classes
{
    public abstract partial class Base : IBase
    {
        public virtual int Id { get; set; }
        public virtual DateTimeOffset Created { get; set; }
        public virtual DateTimeOffset? LastUpdated { get; set; }
        public virtual DateTimeOffset? Deleted { get; set; }
        public static void OnModelCreating<TEntity>(ModelBuilder builder) where TEntity : class, IBase
        {
            builder.Entity<TEntity>().HasKey(entity => entity.Id);
        }
    }
}
