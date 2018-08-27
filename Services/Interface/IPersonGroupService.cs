using System.Collections.Generic;
using Services.ServiceModels;

namespace Services.Interface
{
    public interface IPersonGroupService
    {
        IEnumerable<PersonGroupModel> GetAll();
        PersonGroupModel Add(PersonGroupModel model);
        PersonGroupModel Update(PersonGroupModel model);
        PersonGroupModel GetById(int id);
        void Delete(int id);
    }
}
