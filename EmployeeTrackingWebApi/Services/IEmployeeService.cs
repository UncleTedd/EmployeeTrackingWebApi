using EmployeeTrackingWebApi.Contracts;
using EmployeeTrackingWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingWebApi.Services;

public interface IEmployeeService
{
    Task<List<EmployeeResponse>> GetEmployees();
    Task<EmployeeResponse> GetEmployee(int id);
    List<Position> GetAllPositions();
    Task<EmployeeResponse> AddEmployee(CreateEmployeeRequest employee);
    Task<EmployeeResponse> UpdateEmployee(int id, UpdateEmployeeRequest request);

    Task<int> DeleteEmployee(int id);

    Task<int?> StartShift(StartShiftRequest request);
    Task<int?> EndShift(EndShiftRequest request);
}