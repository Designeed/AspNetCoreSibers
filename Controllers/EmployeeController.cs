using AspNetCoreSibers.Domain.Entities;
using AspNetCoreSibers.Domain.Repositories.EmployeeRepository;
using AspNetCoreSibers.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSibers.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var taskEmployeeList = _employeeRepository.GetEmployeesAsync();

            return View(await taskEmployeeList);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var taskDeletionEmployee = _employeeRepository.DeleteEmployeeByIdAsync(id);

            await taskDeletionEmployee;

            return RedirectToAction(nameof(EmployeeController.Index), nameof(EmployeeController).RemoveController());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            await _employeeRepository.AddEmployeeAsync(employee);

            return RedirectToAction(nameof(EmployeeController.Index), nameof(EmployeeController).RemoveController());
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View();

            var taskEditionEmployee = _employeeRepository.EditEmployeeAsync(employee);

            await taskEditionEmployee;

            return RedirectToAction(nameof(EmployeeController.Index), nameof(EmployeeController).RemoveController());
        }
    }
}
