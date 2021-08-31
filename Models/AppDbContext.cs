using Microsoft.EntityFrameworkCore;


namespace CapInternalProjEmp.Models
{
    public class AppDbContext : DbContext
    {
        
        // We'll use a constructor to create a pth to the server
        // Use generic paramter to apply our options to the AppDbContext class.

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Here we use the options of the base class?
        }

        public DbSet<Employee> Employees { get; set; } // Do we need this?

/*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();


        }
    
    */ //Extension method to add the the model builder class!
    }
}