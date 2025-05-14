using FancyPower3k.DomainModel.Entities;

namespace FancyPower3k.Business.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(string employeeId);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
    }
}