namespace EmployeeTrackingWebApi.Contracts;

public class StartShiftRequest
{
    public int Id { get; set; }
    public DateTime? StartShift { get; set; }
}