using Ambient.Context.Interfaces;
using AutoMapper;
using Repositories.Interface;
using Services.Interface;
using Services.ServiceModels;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementation
{
    public class SeatingService : ISeatingService
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _tableRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonGroupRepository _personGroupRepository;
        private readonly ITableService _tableService;
        private readonly IPersonService _personService;
        private readonly IPersonGroupService _personGroupService;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public SeatingService(
            IMapper mapper, 
            ITableRepository tableRepository,
            IPersonRepository personRepository,
            IPersonGroupRepository personGroupRepository,
            ITableService tableService,
            IPersonService personService,
            IPersonGroupService personGroupService,
            IDbContextScopeFactory contextScopeFactory
        ) {
            _mapper = mapper;
            _tableRepository = tableRepository;
            _personRepository = personRepository;
            _personGroupRepository = personGroupRepository;
            _tableService = tableService;
            _personService = personService;
            _personGroupService = personGroupService;
            _contextScopeFactory = contextScopeFactory;
        }

        public IEnumerable<SeatingModel> GetAll()
        {
            var tables = _tableService.GetAll();
            List<SeatingModel> seating = new List<SeatingModel>();

            foreach (var table in tables)
            {
                seating.Add(new SeatingModel
                {
                    TableId = table.Id,
                    Table = _mapper.Map<TableModel>(table),
                    Persons = _personService.GetAllFromTable(table.Id).ToList()
                });
            }

            return seating;
        }

        public bool RemovePersonFromTable(int personId)
        {
            var person = _personService.GetById(personId);

            if (person != null)
            {
                person.TableId = null;
                _personService.Update(person);
                return true;
            }

            return false;
        }

        public bool AddPersonToTable(int personId, int tableId)
        {
            var person = _personService.GetById(personId);
            var table = _tableService.GetById(tableId);
            var personsAtTable = _personService.GetAllFromTable(tableId).Count();

            if (person != null && table != null && personsAtTable < table.Max_Person)
            {
                person.TableId = tableId;
                _personService.Update(person);
                return true;
            }

            return false;
        }
    }
}
