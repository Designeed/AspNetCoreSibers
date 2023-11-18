using AspNetCoreSibers.Domain.Entities;

namespace AspNetCoreSibers.Domain.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public Task DeleteEmployeeAsync(Guid id);
        public Task AddEmployeeAsync(Employee employee);
        public Task EditEmployeeAsync(Employee employee);
        public Task<Employee> GetEmployeeByIdAsync(Guid id);
        public Task<ICollection<Employee>> GetEmployeesAsync();
    }
}
