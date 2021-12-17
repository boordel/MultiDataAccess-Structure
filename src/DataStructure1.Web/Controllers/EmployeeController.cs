using DataStructure1.Core.ModelData;
using DataStructure1.Core.Models;
using DataStructure1.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataStructure1.Web.Controllers;
public class EmployeeController : Controller
{
    private readonly IEmployeeModelData _modelData;

    public EmployeeController(IEmployeeModelData employeeModelData)
    {
        _modelData = employeeModelData;
        ViewModel = new EmployeeViewModel();
    }

    [BindProperty]
    public EmployeeViewModel ViewModel { get; set; }

    private async Task<IActionResult> GetEmployee(int EmployeeId)
    {
        var data = await _modelData.Get(EmployeeId);

        if (data == null)
            return NotFound();

        ViewModel = new()
        {
            EmployeeId = data.Id,
            FirstName = data.FirstName,
            LastName = data.LastName,
            WorkUnit = data.WorkUnit,
            StartDate = data.StartDate,
            Salary = data.Salary
        };

        return View(ViewModel);
    }

    public async Task<IActionResult> Index()
    {
        var data = await _modelData.GetAll();

        List<EmployeeViewModel> employees = new();
        foreach (var item in data)
            employees.Add(new EmployeeViewModel
            {
                EmployeeId = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                WorkUnit = item.WorkUnit,
                StartDate = item.StartDate,
                Salary = item.Salary
            });

        return View(employees);
    }

    public async Task<IActionResult> Details(int id)
    {
        return await GetEmployee(id);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeViewModel ViewModel)
    {
        if (ModelState.IsValid)
        {
            EmployeeModel newEmployee = new()
            {
                Id = 0,
                FirstName = ViewModel.FirstName,
                LastName = ViewModel.LastName,
                WorkUnit = ViewModel.WorkUnit,
                StartDate = ViewModel.StartDate,
                Salary = ViewModel.Salary
            };
            await _modelData.Insert(newEmployee);

            return RedirectToAction(nameof(Index));
        }
        else
            return View();
    }

    public async Task<IActionResult> Edit(int id)
    {
        return await GetEmployee(id);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EmployeeViewModel ViewModel)
    {
        if (ModelState.IsValid)
        {
            EmployeeModel newEmployee = new()
            {
                Id = ViewModel.EmployeeId,
                FirstName = ViewModel.FirstName,
                LastName = ViewModel.LastName,
                WorkUnit = ViewModel.WorkUnit,
                StartDate = ViewModel.StartDate,
                Salary = ViewModel.Salary
            };
            await _modelData.Update(newEmployee);

            return RedirectToAction(nameof(Index));
        }
        else
            return View();
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _modelData.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
