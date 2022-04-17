using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Meetups.Aplication.Common.Mapping
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) => ApplyMappingFromAssembly(assembly);

        // This method scaning the assebly and searching any types that emplement interface IMapWith
        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var typesThatImplementIMapWith = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in typesThatImplementIMapWith)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
