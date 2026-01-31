using ScriptRunner.Core.Contracts;

namespace ScriptRunner.Core.Mapper
{
    public class Mapper : IMapper
    {

        public TDestination MappingToDestination<TSource, TDestination>(TSource source) where TDestination : new() => Map<TSource, TDestination>(source);


        private TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null)
                return default;

            TDestination destination = new TDestination();
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var property in sourceProperties)
            {
                var properties = destinationProperties.FirstOrDefault(p => p.Name == property.Name && p.PropertyType == property.PropertyType);

                if (properties != null)
                {
                    properties.SetValue(destination, property.GetValue(source));
                }
            }

            return destination;
        }
    }
}
