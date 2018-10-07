using System.Collections.Generic;

namespace Services.ServiceModels
{
    public class SeatingModel
    {
        public int TableId { get; set; }
        public TableModel Table { get; set; }
        public List<PersonModel> Persons { get; set; }
    }
}
