using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Mapper
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            var mappers = GetStandartMaps();
            foreach (var item in mappers)
            {
                CreateMap(item.Source, item.Destination).ReverseMap();
            }
        }

        //Butun IMapTo interfacesine mexsus olan claslari gotururuk
        private static IEnumerable<MapModel> GetStandartMaps()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            return types.Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
                .Select(x => new MapModel
                {
                    Source = x,
                    Destination = x.GetInterfaces().First().GenericTypeArguments[0]
                });
        }
    }
}
