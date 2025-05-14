using FancyPower3k.Business.Core.Contracts;
using FancyPower3k.DataAccess.Data;
using FancyPower3k.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.Business.Core.Services;

public class EmployeeService : IEmployeeService
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

    public async Task<Employee> GetEmployeeByIdAsync(string id)
    {
        return await _context.Employees.Include(e => e.Location)
            .FirstOrDefaultAsync(e => e.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> DeleteEmployeeAsync(string employeeId)
    {
        var exists = await GetEmployeeByIdAsync(employeeId);
        if (exists != null)
        {
            _context.Employees.Remove(exists);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
