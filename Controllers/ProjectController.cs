using AspNetCoreSibers.Domain;
using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Domain.Repositories.EmployeeRepository;
using AspNetCoreSibers.Domain.Repositories.ProjectRepository;
using AspNetCoreSibers.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AspNetCoreSibers.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;


        public ProjectController(IProjectRepository projectRepository, IEmployeeRepository employeeRepository)
        {
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var taskProjectList = _projectRepository.GetProjectsAsync();

            return View(await taskProjectList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
                return View(project);

            var taskCreationProject = _projectRepository.AddProjectAsync(project);

            await taskCreationProject;

            return RedirectToAction(nameof(ProjectController.Index), nameof(ProjectController).RemoveController());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            
            var taskDeletionProject = _projectRepository.DeleteProjectAsync(id);

            await taskDeletionProject;

            return RedirectToAction(nameof(ProjectController.Index), nameof(ProjectController).RemoveController());
        }
    }
}
