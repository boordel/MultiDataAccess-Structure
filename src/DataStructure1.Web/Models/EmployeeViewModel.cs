using System.ComponentModel.DataAnnotations;

namespace DataStructure1.Web.Models;

public class EmployeeViewModel
{
    [Display(Name = "Employee Id")]
    public int EmployeeId { get; set; }
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Display(Name = "Work Unit")]
    public string WorkUnit { get; set; }
    [Display(Name = "Start Date")]
    public string StartDate { get; set; }
    [Display(Name = "Salary")]
    public int Salary { get; set; }

    public EmployeeViewModel()
    {
        FirstName = "";
        LastName = "";
        WorkUnit = "";
        StartDate = "";
        Salary = 0;
    }
    public EmployeeViewModel(int Id, string FirstName, string LastName, string WorkUnit, 
        string StartDate, int Salary)
    {
        EmployeeId = Id;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.WorkUnit = WorkUnit;
        this.StartDate = StartDate;
        this.Salary = Salary;
    }
}
