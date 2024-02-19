namespace EmployeeTrackingWebApi.Contracts;

public class EndShiftRequest
{
    public int Id { get; set; }
    public DateTime? EndShift { get; set; }
}