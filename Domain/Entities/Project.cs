namespace AspNetCoreSibers.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyClientName { get; set; }
        public string CompanyExecutorName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public int Priority { get; set; }
        public List<Employee> Employees { get; set; } = new();
    }
}
