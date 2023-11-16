namespace AspNetCoreSibers.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyClientName { get; set; }
        public string CompanyExecutorName { get; set; }
        public DateOnly ProjectStartDate { get; set; }
        public DateOnly ProjectEndDate { get; set; }
        public int Prierity { get; set; }
        public List<Employee> Employees { get; set; } = new();

    }
}
