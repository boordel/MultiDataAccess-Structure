using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class RegisterManager
{
    private const string DataModelInterface = "IModelData";
    public static void AddModelDataServices(
        this IServiceCollection @this, string AssemblyName)
    {
        var classToRegister = Assembly.Load(AssemblyName)
                                        .DefinedTypes
                                        .Where(t => t.IsClass)
                                        .Where(t => t.GetTypeInfo().ImplementedInterfaces.Count() > 0)
                                        .Where(t => t.GetTypeInfo().ImplementedInterfaces.Any(i => i.Name.Contains(DataModelInterface)))
                                        .Select(t => t.AsType());

        foreach (var serviceClass in classToRegister)
        {
            var serviceType = serviceClass.GetTypeInfo().ImplementedInterfaces.First();
            @this.AddSingleton(serviceType, serviceClass);
        }
    }
}
