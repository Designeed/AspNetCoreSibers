using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Service.Shared;

namespace AspNetCoreSibers.Domain.Models.ProjectModels
{
    public class IndexProjectModel
    {
        public ICollection<Project> Projects { get; set; }
        public ICollection<int> PriorityList { get; set; }
        public IEnumerable<ProjectSortType> ProjectSortTypes { get => Enum.GetValues(typeof(ProjectSortType)).Cast<ProjectSortType>(); }
    }
}
