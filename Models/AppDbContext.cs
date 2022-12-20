using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;

namespace Foodie.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        // space for your DbSet<EntityName> properties

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        //  only derived class can visit it
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            
        }

        //  only derived class can visit it
        // public DbSet<Foodie.Models.Wrapper> Wrapper { get; set; }
    }
}
