namespace EmployeeTrackingWebApi.Services;

public interface IShiftService
{
    DateTime StartShift();
    DateTime EndShift();
    int totalHoursWorked();
}