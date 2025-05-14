using FancyPower3k.DataAccess.Data;
using FancyPower3k.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.Business.Core.Services;

public class EmployeeService
{
    private readonly FancyPowerDbContext _context;

    public EmployeeService(FancyPowerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.Include(e => e.Location).ToListAsync();
    }
}
