using DataStructure1.Core.ModelData;
using DataStructure1.Core.Models;
using DataStructure1.Infra.DataAccess;
using MongoDB.Driver;

namespace DataStructure1.Infra.MongoDB.ModelData;

public class EmployeeModelData : IEmployeeModelData
{
    private readonly IDataAccess _db;
    private readonly string collectionName = "Employees";

    public EmployeeModelData(IDataAccess db)
    {
        _db = db;
    }

    public Task Delete(int Id) =>
        _db.SaveData(collectionName, new BaseModel() { Id = Id }, DataChangeType.Delete);

    public async Task<EmployeeModel?> Get(int Id)
    {
        var filter = Builders<EmployeeModel>.Filter.Eq("Id", Id);
        var result = await _db.LoadData<EmployeeModel, dynamic>(collectionName, filter);
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<EmployeeModel>> GetAll() =>
        await _db.LoadData<EmployeeModel, dynamic>(collectionName, new { });

    public Task Insert(EmployeeModel Model) =>
        _db.SaveData(collectionName, Model, DataChangeType.Insert);

    public Task Update(EmployeeModel Model) =>
        _db.SaveData(collectionName, Model, DataChangeType.Update);
}
