using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext: IdentityDbContext<QuizUser>//creates the db and sets the tables
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }

        public DbSet<Quiz> quiz {get; set;}
        public DbSet<QuizHistory> QuizHistory {get; set;}
        public DbSet<QuizQuestions> quizQuestions{get; set;}
        // creating roles within the DB
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                   new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER",
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}