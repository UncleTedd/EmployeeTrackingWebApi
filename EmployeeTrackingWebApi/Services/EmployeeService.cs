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
    public  async Task<ActionResult<List<Employee>>> GetAllEmployee()
    {
        var result = await _context.Employees.ToListAsync();


    }

    public Task<ActionResult<List<Position>>> GetAllPositions()
    {
        var result = Enum.GetValues(typeof(Position)).Cast<Position>().ToList();
        //var result = (List<Position>)Enum.GetValues(typeof(Position));
        return result;
        
        // var res = _context.Employees.
    }

    public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
    {
        _context.Add(employee);
        var result = await _context.Find(x => x.Id == employee.Id);
        return result;

    }

    

    public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee request)
    {
        var employeeToChange = Employees.Find(x => x.Id == id);
        if (employeeToChange is null)
            return null;
        employeeToChange.Id = request.Id;
        employeeToChange.FirstName = request.FirstName;
        employeeToChange.LastName = request.LastName;
        employeeToChange.FatherName = request.FatherName;
        employeeToChange.Position = request.Position;

        return employeeToChange;
    }

    public int DeleteEmployee(int id)
    {
        var res = Employees.Find(x => x.Id == id);
        if (res is null)
            return 0;

        return Employees.Remove(res) ? 0 : 1;

    }

    public Employee GetSingleEmployee(int id)
    {
        var result = Employees.Find(x=>x.Id == id);
        return result;
    }
}