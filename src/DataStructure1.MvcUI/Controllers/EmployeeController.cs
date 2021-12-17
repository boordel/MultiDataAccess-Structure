using DataStructure1.Core.ModelData;
using DataStructure1.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataStructure1.Web.Controllers;
public class EmployeeController : Controller
{
    private readonly IEmployeeModelData _modelData;

    public EmployeeController(IEmployeeModelData employeeModelData)
    {
        _modelData = employeeModelData;
        viewModel = new EmployeeViewModel();
    }

    [BindProperty]
    public EmployeeViewModel viewModel { get; set; }

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

    public IActionResult Create()
    {
        return View();
    }
}
