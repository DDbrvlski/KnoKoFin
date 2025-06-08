using KnoKoFin.Domain.Helpers;
namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class TransactionServiceType : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public TransactionServiceType() { }

        public static TransactionServiceType Create(string name, string description)
        {
            return new TransactionServiceType
            {
                Name = name,
                Description = description
            };
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
