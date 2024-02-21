namespace EmployeeTrackingWebApi.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public Position Position { get; set; }

    public List<Shifts> Shifts { get; set; } = new();
}