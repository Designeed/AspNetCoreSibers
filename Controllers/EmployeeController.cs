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

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id.HasValue)
                await _employeeRepository.DeleteEmployeeByIdAsync(id.Value);

            return RedirectToAction(nameof(EmployeeController.Index), nameof(EmployeeController).RemoveController());
        }

        public async Task<IActionResult> Index()
        {
            return View(await _employeeRepository.GetEmployeesAsync());
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

            if (employee == null)
                return RedirectToAction(nameof(EmployeeController.Index), nameof(EmployeeController).RemoveController());

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View();

            await _employeeRepository.EditEmployeeAsync(employee);

            return RedirectToAction(nameof(EmployeeController.Index), nameof(EmployeeController).RemoveController());
        }
    }
}
