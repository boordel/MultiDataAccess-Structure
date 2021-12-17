using DataStructure1.Infra.DataAccess;

namespace DataStructure1.Infra.SqlServer.ModelData;

public class EmployeeModelData : IEmployeeModelData
{
    private readonly IDataAccess _db;

    public EmployeeModelData(IDataAccess db)
    {
        _db = db;
    }

    public Task Delete(int Id) =>
        _db.SaveData("dbo.spEmployee_Delete", new { Id });

    public async Task<EmployeeModel?> Get(int Id)
    {
        var result = await _db.LoadData<EmployeeModel, dynamic>("dbo.spEmployee_Get", new { Id });
        return result.FirstOrDefault();
    }

    public Task<IEnumerable<EmployeeModel>> GetAll() =>
        _db.LoadData<EmployeeModel, dynamic>("dbo.spEmployee_GetAll", new { });

    public Task Insert(EmployeeModel Model) =>
        _db.SaveData("dbo.spEmployee_Update", new
        {
            Id = 0,
            Model.FirstName,
            Model.LastName,
            Model.WorkUnit,
            Model.StartDate,
            Model.Salary,
            Mode = "insert"
        });

    public Task Update(EmployeeModel Model) =>
        _db.SaveData("dbo.spEmployee_Update", new
        {
            Model.Id,
            Model.FirstName,
            Model.LastName,
            Model.WorkUnit,
            Model.StartDate,
            Model.Salary,
            Mode = "update"
        });
}
