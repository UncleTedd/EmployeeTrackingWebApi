namespace EmployeeTrackingWebApi.Contracts;

public class CreateEmployeeRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public Position Position { get; set; }
}