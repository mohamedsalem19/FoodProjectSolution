using FoodProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodProject.Data
{
    public class Context : IdentityDbContext<UserApplication>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipesItems> RecipesItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
