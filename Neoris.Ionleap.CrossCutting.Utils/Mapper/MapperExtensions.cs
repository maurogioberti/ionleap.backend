namespace Neoris.Ionleap.CrossCutting.Utils.Mapper
{

    public static class MapperExtensions
    {
        public static TDestination MapObject<TSource, TDestination>(this TSource source)
            where TSource : class
            where TDestination : class
        {
            return AutoMap.Map<TSource, TDestination>(source);
        }
    }
}
