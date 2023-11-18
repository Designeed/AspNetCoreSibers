using AspNetCoreSibers.Domain.Entities;

namespace AspNetCoreSibers.Domain.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        public Task AddProjectAsync(Project project);
        public Task DeleteProjectAsync(Guid id);
        public Task EditProjectAsync(Project project);
        public Task<Project> GetProjectByIdAsync(Guid id);
        public Task<ICollection<Project>> GetProjectsAsync();
    }
}