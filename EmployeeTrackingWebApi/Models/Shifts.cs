namespace EmployeeTrackingWebApi.Models;

public class Shifts
{
    public int Id { get; set; }
    public DateTime StartShift { get; set; }
    public DateTime EndShift { get; set; }
    public DateTime TotalHoursWorked { get; set; }
    public Employee Employee { get; set; }
    
}