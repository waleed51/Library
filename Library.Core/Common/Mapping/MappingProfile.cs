using AutoMapper;
using System.Reflection;

namespace Library.Core.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>) || i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("MappingFrom")
                ?? type.GetInterface("IMapFrom`1")?.GetMethod("MappingFrom");

            methodInfo?.Invoke(instance, new object[] { this });

            methodInfo = type.GetMethod("MappingTo") ?? type.GetInterface("IMapTo`1")?.GetMethod("MappingTo");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
