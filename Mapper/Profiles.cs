using AutoMapper;
using Context.Entities;
using Services.ServiceModels;
using System.Collections.Generic;

namespace Mapper
{
    public static class MapperConfig
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
              new TableProfile(),
              new PersonProfile(),
              new PersonGroupProfile()
            };
        }
    }

    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<Table, TableModel>();
            CreateMap<TableModel, Table>();
        }
    }

    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonModel>();
            CreateMap<PersonModel, Person>();
        }
    }

    public class PersonGroupProfile : Profile
    {
        public PersonGroupProfile()
        {
            CreateMap<PersonGroup, PersonGroupModel>();
            CreateMap<PersonGroupModel, PersonGroup>();
        }
    }
}
