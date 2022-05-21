using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataAccess
{
    public class DatabaseService : IDataService
    {
        private KinderGartenContext ctx;

        public DatabaseService(KinderGartenContext db)
        {
            ctx = db;
        }

        public int AddChild(Child c)
        {
            ctx.Children.Add(c);
            ctx.SaveChanges();
            return c.Age;
        }

        public async Task<Child> AddChildAsync(Child c) 
        {
            EntityEntry<Child> newlyAdded = await ctx.Children.AddAsync(c);
            await ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }   

        public async Task<Toy> AddToyAsync(Toy t)
        {
            var child = await ctx.Children.SingleOrDefaultAsync(c => c.Age == t.ChildOwnerOfToy.Age);
            t.ChildOwnerOfToy = child;

            EntityEntry<Toy> newlyAdded = await ctx.Toys.AddAsync(t);
            await ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public List<Child> GetChildren()
        {
            List<Child> children = (from c in ctx.Children select c).ToList();
            return children;
        }

        public List<Toy> GetToys()
        {
            return ctx.Toys.Include(x => x.ChildOwnerOfToy).ToList();
        }

        public async Task RemoveToyAsync(string age)
        {
            Toy toDelete = await ctx.Toys.FirstOrDefaultAsync(t => t.Name == age);
            if (toDelete != null)
            {
                ctx.Toys.Remove(toDelete);
                await ctx.SaveChangesAsync();
            }
        }

    }
}
