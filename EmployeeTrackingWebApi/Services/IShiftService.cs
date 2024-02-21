namespace EmployeeTrackingWebApi.Services;

public interface IShiftService
{
    DateTime StartShift(int id);
    DateTime EndShift(int id);
    double totalHoursWorked();
}