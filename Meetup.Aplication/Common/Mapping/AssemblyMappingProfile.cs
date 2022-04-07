using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Common.Mapping
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) => ApplyMappingFromAssembly(assembly);

        /// <summary>
        /// This method scaning the assebly and searching any types that emplement interface IMapWith 
        /// </summary>
        /// <param name="assembly"></param>
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
