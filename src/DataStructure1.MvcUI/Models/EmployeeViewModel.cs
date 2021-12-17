namespace DataStructure1.Web.Models;

public class EmployeeViewModel
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string WorkUnit { get; set; }
    public string StartDate { get; set; }
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
