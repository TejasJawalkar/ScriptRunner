namespace ScriptRunner.Core.Contracts
{
    public interface IMapper
    {
        TDestination MappingToDestination<TSource, TDestination>(TSource source)
        where TDestination : new();
    }
}
