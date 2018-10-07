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
    public class TableService : ITableService
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _tableRepository;

        public TableService(
            IMapper mapper, 
            ITableRepository tableRepository
        ) {
            _mapper = mapper;
            _tableRepository = tableRepository;
        }

        public IEnumerable<TableModel> GetAll()
        {
            var entities = _tableRepository.GetAllActive().ToList();
            return _mapper.Map<List<TableModel>>(entities);
        }

        public TableModel Add(TableModel model)
        {
            var entity = _mapper.Map<Table>(model);
            _tableRepository.Add(entity);
            _tableRepository.Save();
            return model;
        }

        public TableModel Update(TableModel model)
        {
            var entity = _tableRepository.GetById(model.Id);

            entity.Name = model.Name;
            entity.Max_Person = model.Max_Person;
            entity.Description = model.Description;

            _tableRepository.Edit(entity);
            _tableRepository.Save();

            return model;
        }

        public void Delete(int id)
        {
            _tableRepository.Delete(id);
            _tableRepository.Save();
        }

        public TableModel GetById(int id)
        {
            var entity = _tableRepository.GetById(id);
            return _mapper.Map<TableModel>(entity);
        }
    }
}
