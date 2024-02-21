using System.Xml.Linq;
using EmployeeTrackingWebApi.Contracts;
using EmployeeTrackingWebApi.DbContext;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackingWebApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<EmployeeResponse>> GetEmployees()
    {
        var result = await _context.Employees.Include(x => x.Shifts).ToListAsync();
        return result.Select(x => MapToEmployeeResponse(x)).ToList();
    }

    
    public async Task<EmployeeResponse> GetEmployee(int id)
    {
        var result = await _context.Employees.Include(x=>x.Shifts).FirstOrDefaultAsync();
        return MapToEmployeeResponse(result);
    }
    
    
    
    public List<Position> GetAllPositions()
    {
        var result = Enum.GetValues(typeof(Position)).Cast<Position>().ToList();

        return result;
    }

    public async Task<EmployeeResponse> AddEmployee(CreateEmployeeRequest employee)
    {
        if (employee == null || string.IsNullOrEmpty(employee.FatherName) || string.IsNullOrEmpty(employee.FirstName) ||
            string.IsNullOrEmpty(employee.LastName) || employee.Position <= 0)
            return null;


        var emplEntity = new Employee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            FatherName = employee.FatherName,
            Position = employee.Position,
        };
        _context.Add(emplEntity);
        await _context.SaveChangesAsync();
        var entity = await _context.Employees.FirstAsync(x => x.Id == emplEntity.Id);
        return MapToEmployeeResponse(entity);
    }

    public async Task<EmployeeResponse> UpdateEmployee(int id, UpdateEmployeeRequest request)
    {
        var employeeToChange = await _context.Employees.FindAsync(id);
        if (employeeToChange is null)
            return null;
        employeeToChange.FirstName = request.FirstName;
        employeeToChange.LastName = request.LastName;
        employeeToChange.FatherName = request.FatherName;
        employeeToChange.Position = request.Position;

        await _context.SaveChangesAsync();


        return MapToEmployeeResponse(employeeToChange);
    }

    public async Task<int> DeleteEmployee(int id)
    {
        var res = await _context.Employees.FindAsync(id);

        _context.Remove(res);
        return await _context.SaveChangesAsync();
    }

    

    public async Task<int?> StartShift(StartShiftRequest request)
    {
        var id = request.Id;
        var employee = await _context.Employees.Include(x => x.Shifts).FirstOrDefaultAsync(x => x.Id == id);
        if (employee == null)
        {
            return null;
        }

        var areAllShiftsEnded = !employee.Shifts.Any(x => x.EndShift == null);
        if (!areAllShiftsEnded) return null;


        employee.Shifts.Add(new Shifts
        {
            Id = 0,
            StartShift = DateTime.Now,
            EndShift = null,
            TotalHoursWorked = 0,
        });


        return await _context.SaveChangesAsync();
    }

    public async Task<int?> EndShift(EndShiftRequest request)
    {
        var id = request.Id;

        var employee = await _context.Employees.Include(x => x.Shifts).FirstOrDefaultAsync(x => x.Id == id);

        if (employee is null)
        {
            return null;
        }

        var areAllShiftsStarted = !employee.Shifts.Any(x => x.StartShift == null);
        if (!areAllShiftsStarted) return null;

        var shift = employee.Shifts.FirstOrDefault(x => x.EndShift == null);
        shift.EndShift = request.EndShift;
        var totalMinutes = (shift.EndShift - shift.StartShift)?.TotalMinutes;
        var result = totalMinutes / 60d;
        var totalHours = Math.Round(result.Value, 2);
        shift.TotalHoursWorked = totalHours;
        return await _context.SaveChangesAsync();
    }


    private static EmployeeResponse MapToEmployeeResponse(Employee entity)
    {
        return new EmployeeResponse
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            FatherName = entity.FatherName,
            Position = entity.Position,
            Shifts = entity.Shifts.Select(y => new ShiftResponse
            {
                Id = y.Id,
                StartShift = y.StartShift,
                EndShift = y.EndShift,
                TotalHoursWorked = y.TotalHoursWorked
            }).ToList()
        };
    }
}