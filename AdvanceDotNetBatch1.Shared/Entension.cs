namespace AdvanceDotNetBatch1.Shared
{
    public static class Entension
    {
        public static IQueryable<TSource> Paginate<TSource>(
        this IQueryable<TSource> source,
        int pageNo,
        int pageSize
    )
        {
            return source.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }
    }
}
