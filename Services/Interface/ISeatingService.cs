using Services.ServiceModels;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface ISeatingService
    {
        IEnumerable<SeatingModel> GetAll();
        bool RemovePersonFromTable(int personId);
        bool AddPersonToTable(int personId, int tableId);
    }
}
