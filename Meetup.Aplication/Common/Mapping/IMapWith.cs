using AutoMapper;

namespace Meetups.Aplication.Common.Mapping
{
    /// <summary>
    /// Interface with default implementation. Mapping method will create configuration from type T to purpouse type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
