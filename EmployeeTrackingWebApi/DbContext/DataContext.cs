namespace EmployeeTrackingWebApi.DbContext;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseMySql("server=localhost;port=3306;database=employeeTrackingDB;user=root;password=root;",
            new MariaDbServerVersion("11.1.2"));
    }

    public DbSet<Employee> Employees { get; set; }
    
}