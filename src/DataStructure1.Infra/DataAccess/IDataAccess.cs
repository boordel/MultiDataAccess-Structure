namespace DataStructure1.Infra.DataAccess;

public interface IDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string commandOrObject,
                                        U parameters,
                                        string connectionId = "DefaultCnn");
    Task SaveData<T>(string commandOrObject,
                     T parameters,
                     DataChangeType changeType = DataChangeType.Command,
                     string connectionId = "DefaultCnn");
}
