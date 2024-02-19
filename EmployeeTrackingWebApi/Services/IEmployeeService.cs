using EmployeeTrackingWebApi.Contracts;
using EmployeeTrackingWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingWebApi.Services;

public interface IEmployeeService
{
    Task<List<EmployeeResponse>> GetAllEmployee();
    Task<Employee> GetSingleEmployee(int id);
    List<Position> GetAllPositions();
    Task<Employee> AddEmployee(CreateEmployeeRequest employee);
    Task<Employee> UpdateEmployee(int id, UpdateEmployeeRequest request);

    Task<int> DeleteEmployee(int id);

    Task<int> StartShift(StartShiftRequest request);
    Task<int> EndShift(EndShiftRequest request);
}