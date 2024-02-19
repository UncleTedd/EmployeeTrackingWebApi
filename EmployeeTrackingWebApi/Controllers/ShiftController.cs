using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrackingWebApi.Controllers;

public class ShiftController : Controller
{
    private Employee employee = new Employee();
    
    public DateTime StartShift(int employeeId)
    {
        employee.Shifts.Add(new Shifts
        {
            StartShift = DateTime.Now,
            EndShift = null,
            TotalHoursWorked = 0,
        });
        return DateTime.Now;
    }
    
    public DateTime EndShift(int employeeId)
    {
        employee.Shifts.Add(new Shifts()
        {
            EndShift = DateTime.Now
        });
        return DateTime.Now;
    }
    
}