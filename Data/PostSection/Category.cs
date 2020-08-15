using BlazingSite.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingSite.Data.PostSection
{
    public partial class Category : Base
    {
        public virtual string Name { get; set; }
        public virtual bool Enabled { get; set; }
    }
}
