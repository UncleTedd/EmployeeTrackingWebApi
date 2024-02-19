using EmployeeTrackingWebApi.DbContext;

namespace EmployeeTrackingWebApi.Services;

public class ShiftService : IShiftService
{
    private readonly DataContext _context;

    public ShiftService(DataContext context)
    {
        _context = context;
    }
    
    
    
    public DateTime StartShift(int id)
    {
        return DateTime.Now;
    }

    public DateTime EndShift(int id)
    {
        return DateTime.Now;
    }

    public int totalHoursWorked()
    {
        return 0;
    }
}