using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models
{
    public class MyDBContext : DbContext
    {
       public MyDBContext(){}
       public DbSet<Employee> Employees { get; set; }
       public DbSet<Department> departments { get; set; }
       public DbSet<Project> projects { get; set; }
       public DbSet<WorksOn> worksOns { get; set; }
       public DbSet<Dependent> dependents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Company;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        
        }
        
    }
}
