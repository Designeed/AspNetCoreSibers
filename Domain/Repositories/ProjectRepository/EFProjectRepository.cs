using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Service.Shared;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSibers.Domain.Repositories.ProjectRepository
{
    public class EFProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _dbContext;

        public EFProjectRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProjectAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectByIdAsync(Guid id)
        {
            _dbContext.Projects.Remove(new Project { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditProjectAsync(Project project)
        {
            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(Guid id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ICollection<Project>> GetSortedProjectListAsync(ProjectSortType sortType)
        {
            var projectCollection = _dbContext.Projects.Select(project => project);

            projectCollection = sortType switch
            {
                ProjectSortType.Name => projectCollection.OrderBy(project => project.Name),
                ProjectSortType.StartDate => projectCollection.OrderBy(project => project.ProjectStartDate),
                ProjectSortType.EndDate => projectCollection.OrderBy(project => project.ProjectEndDate),
                ProjectSortType.Priority => projectCollection.OrderBy(project => project.Priority)
            };

            return await projectCollection.ToListAsync();
        }
    }
}
