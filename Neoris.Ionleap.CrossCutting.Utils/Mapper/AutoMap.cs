using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Neoris.Ionleap.CrossCutting.Utils.Mapper
{
    public static class AutoMap
    {
        /// <summary>
        /// Generates a simple mapping from source model and destination model
        /// </summary>
        /// <typeparam name="TSource">Origin source class</typeparam>
        /// <typeparam name="TDestination">Destination class</typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        public static TDestination Map<TSource, TDestination>(TSource map)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());

            IMapper iMapper = mapper.CreateMapper();

            return iMapper.Map<TSource, TDestination>(map);
        }

        /// <summary>
        /// Generates a simple mapping from source model and destination model from a list
        /// </summary>
        /// <typeparam name="TSource">Origin source class</typeparam>
        /// <typeparam name="TDestination">Destination class</typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        public static List<TDestination> Map<TSource, TDestination>(List<TSource> map)
        {
            List<TDestination> destinations = new List<TDestination>();

            if (map == null || !map.Any())
            {
                return new List<TDestination>();
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            IMapper iMapper = mapper.CreateMapper();

            
            foreach (var m in map)
            {
                destinations.Add(iMapper.Map<TSource, TDestination>(m));
            }

            return destinations;
        }
    }
}