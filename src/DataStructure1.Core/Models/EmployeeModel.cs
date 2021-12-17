namespace DataStructure1.Core.Models;

public class EmployeeModel: BaseModel
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string WorkUnit { get; set; } = "";
    public string StartDate { get; set; } = "";
    public int Salary { get; set; } = 0;
}
