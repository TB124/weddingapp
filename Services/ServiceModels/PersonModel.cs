namespace Services.ServiceModels
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TableId { get; set; }
        public int PersonGroupId { get; set; }
        public int Gift { get; set; }
        public string Description { get; set; }
    }

    public class PersonDetailedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TableId { get; set; }
        public TableModel Table { get; set; }
        public int PersonGroupId { get; set; }
        public PersonGroupModel PersonGroup { get; set; }
        public int Gift { get; set; }
        public string Description { get; set; }
    }
}
