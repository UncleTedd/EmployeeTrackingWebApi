using EmployeeTrackingWebApi.DbContext;
using EmployeeTrackingWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackingWebApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }
    
    public static List<Employee> Employees = new()
    {
        new Employee()
        {
            Id = 1,
            FirstName = "Osim",
            LastName = "GUlakov",
            FatherName = "Akbarovich",
            Position = Position.Engineer
        },
        new Employee()
        {
            Id = 2,
            FirstName = "Aziz",
            LastName = "Gulakov",
            FatherName = "Akbarovich",
            Position = Position.Manager
        },
        new Employee()
        {
            Id = 3,
            FirstName = "Sam",
            LastName = "Gulakov",
            FatherName = "Akbarovich",
            Position = Position.Tester
        }

    };
    public  async Task<List<Employee>> GetAllEmployee()
    {
        var result = await _context.Employees.ToListAsync();
        return result;

    }

    public List<Position> GetAllPositions()
    {
        var result = Enum.GetValues(typeof(Position)).Cast<Position>().ToList();
        
        return result;
        
        // var res = _context.Employees.
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();
        return await _context.Employees.FirstAsync(x => x.Id == employee.Id);
    }

    

    public async Task<Employee> UpdateEmployee(int id, Employee request)
    {
        var employeeToChange = await _context.Employees.FindAsync(id);
        if (employeeToChange is null)
            return null;
        employeeToChange.FirstName = request.FirstName;
        employeeToChange.LastName = request.LastName;
        employeeToChange.FatherName = request.FatherName;
        employeeToChange.Position = request.Position;

        await _context.SaveChangesAsync();
        return employeeToChange;
    }

    public int DeleteEmployee(int id)
    {
        var res = Employees.Find(x => x.Id == id);
        if (res is null)
            return 0;

        return Employees.Remove(res) ? 0 : 1;

    }

    public async Task<Employee> GetSingleEmployee(int id)
    {
        var result = await _context.Employees.FindAsync(id);
        return result;
    }
}