using AspNetCoreSibers.Domain;
using AspNetCoreSibers.Domain.Repositories.ProjectRepository;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSibers.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IActionResult> List()
        {
           
            return View(await _projectRepository.GetProjectsAsync());
        }

        
        public IActionResult Add()
        {
            return View();
        }
    }
}
