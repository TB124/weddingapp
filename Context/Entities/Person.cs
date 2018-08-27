namespace Context.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; }

        public int PersonGroupId { get; set; }
        public PersonGroup PersonGroup { get; set; }

        public int Gift { get; set; }

        public string Description { get; set; }
    }
}