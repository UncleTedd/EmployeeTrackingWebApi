namespace EmployeeTrackingWebApi.DbContext;

using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    
    public DbSet<Employee> Employees { get; set; }
}