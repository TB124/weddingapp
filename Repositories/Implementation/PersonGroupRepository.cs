using Ambient.Context.Interfaces;
using Context.Entities;
using Infrastructure.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class PersonGroupRepository : GenericRepository<PersonGroup>, IPersonGroupRepository
    {

        public PersonGroupRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }
    }
}
