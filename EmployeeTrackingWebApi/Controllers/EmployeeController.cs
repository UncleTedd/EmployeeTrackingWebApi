using EmployeeTrackingWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]


public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService service)
    {
        _employeeService = service;
    }
    // public static List<Employee> Employees = new()
    // {
    //     new Employee()
    //     {
    //         Id = 1,
    //         FirstName = "Osim",
    //         LastName = "GUlakov",
    //         FatherName = "Akbarovich",
    //         Position = Position.Engineer
    //     },
    //     new Employee()
    //     {
    //         Id = 2,
    //         FirstName = "Aziz",
    //         LastName = "Gulakov",
    //         FatherName = "Akbarovich", 
    //         Position = Position.Manager
    //     },
    //     new Employee()
    //     {
    //         Id = 3,
    //         FirstName = "Sam",
    //         LastName = "Gulakov",
    //         FatherName = "Akbarovich",
    //         Position = Position.Tester
    //     }
    //
    // };
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetAllEmployee()
    {
        return await _employeeService.GetAllEmployee();
    }
    
    [HttpGet("{id}")]
    public Employee GetSingleEmployee(int id)
    {
        return _employeeService.GetSingleEmployee(id);
    }
    
    [HttpPost]
    public Employee AddEmployee(Employee employee)
    {
        _employeeService.AddEmployee(employee);
        var result = _employeeService.Find(x => x.Id == employee.Id);
        if (result is null)
            return null;
        return result;
        
    }
    [HttpDelete]
    public int DeleteEmployee(int id)
    {
        var res = Employees.Find(x => x.Id == id);
        if (res is null)
            NotFound();
        return Employees.Remove(res) ? 1 : 0;

    }
    
    [HttpPut("{id}")]
    public Employee UpdateEmployee(int id, Employee request)
    {
        _employeeService.UpdateEmployee(id, request);
        var result = Employees.Find(x => x.Id == id);
        return result;

    }
    
}