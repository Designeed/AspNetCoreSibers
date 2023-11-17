using AspNetCoreSibers.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSibers.Domain.Repositories.EmployeeRepository
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EFEmployeeRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            _dbContext.Employees.Remove(new Employee { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditEmployeeAsync(Employee employee)
        {
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IReadOnlyList<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }
    }
}
