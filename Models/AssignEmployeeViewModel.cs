using AspNetCoreSibers.Domain.Entities;

namespace AspNetCoreSibers.Models
{
    public class AssignEmployeeViewModel
    {
        public Project Project { get; set; }
        public ICollection<Employee> AvailableEmployees { get; set; }
    }
}
