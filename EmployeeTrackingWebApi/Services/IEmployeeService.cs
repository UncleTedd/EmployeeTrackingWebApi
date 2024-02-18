using EmployeeTrackingWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingWebApi.Services;

public interface IEmployeeService
{
    Task<ActionResult<List<Employee>>> GetAllEmployee();
    Task<ActionResult<Employee>> GetSingleEmployee(int id);
    Task<ActionResult<List<Position>>> GetAllPositions();
    Task<ActionResult<Employee>> AddEmployee(Employee employee);
    Task<ActionResult<Employee>> UpdateEmployee(int id, Employee request);
    
    int DeleteEmployee(int id);

}