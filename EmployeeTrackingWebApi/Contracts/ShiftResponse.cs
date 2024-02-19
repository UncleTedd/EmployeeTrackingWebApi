namespace EmployeeTrackingWebApi.Contracts;

public class ShiftResponse
{
    public int Id { get; set; }
    public DateTime? StartShift { get; set; }
    public DateTime? EndShift { get; set; }
    public int TotalHoursWorked { get; set; }
  
}