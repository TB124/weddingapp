using System.Collections.Generic;
using Services.ServiceModels;

namespace Services.Interface
{
    public interface ITableService
    {
        IEnumerable<TableModel> GetAll();
        TableModel Add(TableModel model);
        TableModel Update(TableModel model);
        TableModel GetById(int id);
        void Delete(int id);
    }
}
