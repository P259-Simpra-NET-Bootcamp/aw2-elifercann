using Entities.Models;
using Microsoft.EntityFrameworkCore;
using static Entities.Models.Staff;

namespace Repositories.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Staff> Staffs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
