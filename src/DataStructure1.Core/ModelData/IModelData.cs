namespace DataStructure1.Core.ModelData;

public interface IModelData<T>
{
    Task<T?> Get(int Id);
    Task<IEnumerable<T>> GetAll();
    Task Delete(int Id);
    Task Insert(T Model);
    Task Update(T Model);
}
