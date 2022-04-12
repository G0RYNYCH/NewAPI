using AutoMapper;

namespace Meetups.Aplication.Common.Mapping
{
    // Interface with default implementation. Mapping method will create configuration from type T to purpose type.    
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
