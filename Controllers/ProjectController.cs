using AspNetCoreSibers.Domain;
using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Domain.Repositories.ProjectRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AspNetCoreSibers.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IActionResult> Index()
        {
            var taskProjectList = _projectRepository.GetProjectsAsync();

            return View(await taskProjectList);
        }


        public IActionResult Add()
        {
            return View();
        }
    }
}
