using System.Reflection;

namespace Educational.Application.Common.Mappings
{
    public class AssemblyMappingProfile : AutoMapper.Profile
    {

        public AssemblyMappingProfile(Assembly assembly) => ApplyMappingFromAssembly(assembly);
            
        private void ApplyMappingFromAssembly(Assembly assembly) 
        { 
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && 
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach ( var type in types ) 
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }

            new MapConfigurations(this);
        }
    }
}
