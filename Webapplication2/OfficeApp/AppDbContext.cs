using Microsoft.EntityFrameworkCore;
using OfficeApp.Models;

namespace OfficeApp
{
    public class AppDBContext: IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        
    }
    public DbSet<Department> Departments { get; set; }

    public DbSet<Employee> Employees { get; set; }
    

}
}