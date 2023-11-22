using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Service.Shared;

namespace AspNetCoreSibers.Domain.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        public Task AddProjectAsync(Project project);
        public Task DeleteProjectByIdAsync(Guid id);
        public Task EditProjectAsync(Project project);
        public Task<Project?> GetProjectByIdAsync(Guid id);
        public Task<ICollection<Project>> GetSortedProjectListAsync(ProjectSortType sortType, int priorityFilterParameter);
        public Task<ICollection<int>> GetPriorityListAsync();
    }
}