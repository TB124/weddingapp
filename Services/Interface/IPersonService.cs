using System.Collections.Generic;
using Services.ServiceModels;

namespace Services.Interface
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> GetAll();
        PersonModel Add(PersonModel model);
        PersonModel Update(PersonModel model);
        PersonModel GetById(int id);
        void Delete(int id);
    }
}
