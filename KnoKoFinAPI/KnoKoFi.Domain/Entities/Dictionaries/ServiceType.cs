using KnoKoFin.Domain.Helpers;
namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class ServiceType : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ServiceType() { }

        public static ServiceType Create(string name, string description)
        {
            return new ServiceType
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
