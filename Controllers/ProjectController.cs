using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Domain.Repositories.ProjectRepository;
using AspNetCoreSibers.Models;
using AspNetCoreSibers.Service;
using AspNetCoreSibers.Service.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSibers.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IndexProjectViewModelModel indexProjectModel = new();

        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IActionResult> Index(ProjectSortType sortType = ProjectSortType.Name, int priorityValue = Constants.DEFAULT_PRIORITY_FILTER_PARAMETER)
        {
            ViewData["CurrentSortType"] = sortType;
            ViewData["CurrentPriority"] = priorityValue;

            indexProjectModel.Projects = await _projectRepository.GetSortedProjectListAsync(ViewBag.CurrentSortType, ViewBag.CurrentPriority);
            indexProjectModel.PriorityList = await _projectRepository.GetPriorityListAsync();

            return View(indexProjectModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var taskDeletionProject = _projectRepository.DeleteProjectByIdAsync(id);

            await taskDeletionProject;

            return RedirectToAction(nameof(ProjectController.Index), nameof(ProjectController).RemoveController());
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

        public async Task<IActionResult> Edit(Guid id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);

            return View(project);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Project project)
        {
            if (!ModelState.IsValid)
                return View(project);

            var taskEditionProject = _projectRepository.EditProjectAsync(project);

            await taskEditionProject;

            return RedirectToAction(nameof(ProjectController.Index), nameof(ProjectController).RemoveController());
        }
    }
}
