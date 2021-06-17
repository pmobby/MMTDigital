using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Entities;

namespace Web.Infrastructure.EF_Core
{
    public class MMTShopContext : DbContext
    {
        public MMTShopContext(DbContextOptions<MMTShopContext> options) : base(options)
        {            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
