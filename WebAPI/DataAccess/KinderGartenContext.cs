using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataAccess
{
    public class KinderGartenContext : DbContext
    {
        public KinderGartenContext(DbContextOptions<KinderGartenContext> options)
         : base(options)
        {
        }
        public DbSet<Toy> Toys { get; set; }

        public DbSet<Child> Children { get; set; }

    }
}
