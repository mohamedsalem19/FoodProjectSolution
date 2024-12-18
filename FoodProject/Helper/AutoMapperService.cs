using AutoMapper;

namespace FoodProject.Services
{
    public static class AutoMapperService
    {
        public static IMapper Mapper { get; set; }

        public static IQueryable<T> ProjectTo<T>(this IQueryable<object> source)
        {
            return Mapper.ProjectTo<T>(source);
        }

        public static T MapFirstOrDefault<T>(this IQueryable<object> source)
        {
            return Mapper.ProjectTo<T>(source).FirstOrDefault();
        }

        public static T Map<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

    }
}
