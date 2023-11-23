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
            if (project.ProjectEndDate > DateTime.Now)
                project.ProjectEndDate = DateTime.Now;

            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(Guid id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ICollection<Project>> GetSortedProjectListAsync(ProjectSortType sortType, int priorityFilterParameter)
        {
            var projectCollection = _dbContext.Projects.Select(project => project);

            projectCollection = sortType switch
            {
                ProjectSortType.Name => projectCollection.OrderBy(project => project.Name),
                ProjectSortType.StartDate => projectCollection.OrderBy(project => project.ProjectStartDate),
                ProjectSortType.EndDate => projectCollection.OrderBy(project => project.ProjectEndDate),
                ProjectSortType.Priority => projectCollection.OrderBy(project => project.Priority)
            };

            if (priorityFilterParameter != Constants.DEFAULT_PRIORITY_FILTER_PARAMETER)
                projectCollection = projectCollection.Where(project => project.Priority == priorityFilterParameter);

            return await projectCollection.ToListAsync();
        }

        public async Task<ICollection<int>> GetPriorityListAsync()
        {
            return await _dbContext
                .Projects
                .OrderBy(project => project.Priority)
                .Select(project => project.Priority)
                .Distinct()
                .ToListAsync();
        }
    }
}
