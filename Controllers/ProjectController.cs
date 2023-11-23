using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Domain.Repositories.EmployeeRepository;
using AspNetCoreSibers.Domain.Repositories.ProjectRepository;
using AspNetCoreSibers.Models;
using AspNetCoreSibers.Service;
using AspNetCoreSibers.Service.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AspNetCoreSibers.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IndexProjectViewModelModel indexProjectModel = new();

        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ProjectController(IProjectRepository projectRepository, IEmployeeRepository employeeRepository)
        {
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
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

        public async Task<IActionResult> AssignEmployee(Guid id)
        {
            AssignEmployeeViewModel assignEmployeeModel = new()
            {
                Project = await _projectRepository.GetProjectByIdAsync(id) ?? new Project(),
                AvailableEmployees = await _employeeRepository.GetEmployeesAsync()
            };

            return View(assignEmployeeModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssignEmployee(Guid? employeeId, Guid? projectId)
        {
            if (!(employeeId.HasValue && projectId.HasValue))
                return RedirectToAction(nameof(ProjectController.Index), nameof(ProjectController).RemoveController());

            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId.Value);
            var project = await _projectRepository.GetProjectByIdAsync(projectId.Value);
            var employees = await _employeeRepository.GetEmployeesAsync();

            if (employee == null || project == null)
                return RedirectToAction(nameof(ProjectController.Index), nameof(ProjectController).RemoveController());

            AssignEmployeeViewModel assignEmployeeProjectModel = new()
            {
                Project = project,
                AvailableEmployees = employees
            };

            if (project.Employees.Contains(employee))
                assignEmployeeProjectModel.Project.Employees.Remove(employee);

            else
                assignEmployeeProjectModel.Project.Employees.Add(employee);

            await _projectRepository.EditProjectAsync(assignEmployeeProjectModel.Project);

            return View(assignEmployeeProjectModel);
        }
    }
}
