using EmployeeTrackingWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingWebApi.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllEmployee();
    Task<Employee> GetSingleEmployee(int id);
    List<Position> GetAllPositions();
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> UpdateEmployee(int id, Employee request);
    
    int DeleteEmployee(int id);

}