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
    public class PersonGroupService : IPersonGroupService
    {
        private readonly IMapper _mapper;
        private readonly IPersonGroupRepository _personGroupRepository;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public PersonGroupService(
            IMapper mapper,
            IPersonGroupRepository personGroupRepository,
            IDbContextScopeFactory contextScopeFactory
        )
        {
            _mapper = mapper;
            _personGroupRepository = personGroupRepository;
            _contextScopeFactory = contextScopeFactory;
        }

        public IEnumerable<PersonGroupModel> GetAll()
        {
            var entities = _personGroupRepository.GetAllActive().ToList();
            return _mapper.Map<List<PersonGroupModel>>(entities);
        }

        public PersonGroupModel Add(PersonGroupModel model)
        {
            var entity = _mapper.Map<PersonGroup>(model);
            _personGroupRepository.Add(entity);
            _personGroupRepository.Save();
            return model;
        }

        public PersonGroupModel Update(PersonGroupModel model)
        {
            var entity = _personGroupRepository.GetById(model.Id);

            entity.Name = model.Name;
            entity.Gift = model.Gift;
            entity.Description = model.Description;

            _personGroupRepository.Edit(entity);
            _personGroupRepository.Save();

            return model;
        }

        public void Delete(int id)
        {
            _personGroupRepository.Delete(id);
            _personGroupRepository.Save();
        }

        public PersonGroupModel GetById(int id)
        {
            var entity = _personGroupRepository.GetById(id);
            return _mapper.Map<PersonGroupModel>(entity);
        }
    }
}
