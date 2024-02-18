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
    public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
    {
        var res = await _employeeService.GetSingleEmployee(id);
        return Ok(res);
    }
    
    [HttpPost]
    public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
    {
        var res= await _employeeService.AddEmployee(employee);
        return Ok(res);
    }
    [HttpDelete]
    public int DeleteEmployee(int id)
    {
        return _employeeService.DeleteEmployee(id); 

    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee request)
    {
        var result = await _employeeService.UpdateEmployee(id, request);
        return Ok(result);

    }
    
}