using System.Collections.Generic;
using System.Linq;
using Ambient.Context.Interfaces;
using Context.Entities;
using Repositories.Interface;
using Services.Interface;
using Services.ServiceModels;
using AutoMapper;

namespace Services.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public PersonService(
            IMapper mapper,
            IPersonRepository personRepository
        )
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public IEnumerable<PersonModel> GetAll()
        {
            var entities = _personRepository.GetAllActive().ToList();
            return _mapper.Map<List<PersonModel>>(entities);
        }

        public IEnumerable<PersonModel> GetAllFromTable(int tableId)
        {
            var entities = _personRepository.GetAllActive().Where(x => x.TableId == tableId).ToList();
            return _mapper.Map<List<PersonModel>>(entities);
        }

        public PersonModel Add(PersonModel model)
        {
            var entity = _mapper.Map<Person>(model);
            _personRepository.Add(entity);
            _personRepository.Save();
            return model;
        }

        public PersonModel Update(PersonModel model)
        {
            var entity = _personRepository.GetById(model.Id);

            entity.Name = model.Name;
            entity.TableId = model.TableId;
            entity.PersonGroupId = model.PersonGroupId;
            entity.Gift = model.Gift;
            entity.Description = model.Description;

            _personRepository.Edit(entity);
            _personRepository.Save();

            return model;
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
            _personRepository.Save();
        }

        public PersonModel GetById(int id)
        {
            var entity = _personRepository.GetById(id);
            return _mapper.Map<PersonModel>(entity);
        }
    }
}
