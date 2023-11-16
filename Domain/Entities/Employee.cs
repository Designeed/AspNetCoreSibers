namespace AspNetCoreSibers.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public List<Project> Projects { get; set; } = new();
    }
}
