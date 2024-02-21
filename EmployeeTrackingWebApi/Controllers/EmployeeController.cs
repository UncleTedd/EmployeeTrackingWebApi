using EmployeeTrackingWebApi.Contracts;
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

    [HttpGet]
    public async Task<ActionResult<List<EmployeeResponse>>> GetEmployees()
    {
        return await _employeeService.GetEmployees();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var res = await _employeeService.GetEmployee(id);
        return Ok(res);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeResponse>> AddEmployee([FromBody] CreateEmployeeRequest request)
    {
        var res = await _employeeService.AddEmployee(request);
        if (res == null) return BadRequest();

        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteEmployee([FromRoute] int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeResponse>> UpdateEmployee(int id, UpdateEmployeeRequest request)
    {
        var result = await _employeeService.UpdateEmployee(id, request);
        return Ok(result);
    }

    [HttpPost("startShift")]
    public async Task<ActionResult<Employee>> StartShift([FromBody] StartShiftRequest request)
    {
        var res = await _employeeService.StartShift(request);
        if (res == null)
        {
            return BadRequest();
        }

        return Ok(res);
    }


    [HttpPost("endShift")]
    public async Task<ActionResult<Employee>> EndShift([FromBody] EndShiftRequest request)
    {
        var res = await _employeeService.EndShift(request);
        if (res == null)
        {
            return BadRequest();
        }

        return Ok(res);
    }
}