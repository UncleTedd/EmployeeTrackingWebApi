namespace EmployeeTrackingWebApi.Contracts;

public class EmployeeResponse
{
    public int  Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public Position Position { get; set; }

    public List<ShiftResponse> Shifts { get; set; } = new();
}