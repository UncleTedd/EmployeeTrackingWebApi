using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingWebApi.Controllers;

public class ShiftController : Controller
{
    private Employee employee = new Employee();
    
    public DateTime StartShift(int employeeId)
    {
        employee.Shifts.Add(new Shifts()
        {
            Id = employeeId,
            StartShift = DateTime.Now,
            
            
        });
        return DateTime.Now;
    }
    
    public DateTime EndShift(int employeeId)
    {
        return DateTime.Now;
    }
    
}