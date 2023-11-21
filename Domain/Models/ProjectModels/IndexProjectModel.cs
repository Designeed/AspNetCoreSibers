using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Service.Shared;

namespace AspNetCoreSibers.Domain.Models.ProjectModels
{
    public class IndexProjectModel
    {
        public ICollection<Project> Projects { get; set; }
        public IEnumerable<ProjectSortType> GetProjectSortTypes { get => Enum.GetValues(typeof(ProjectSortType)).Cast<ProjectSortType>(); }
    }
}
