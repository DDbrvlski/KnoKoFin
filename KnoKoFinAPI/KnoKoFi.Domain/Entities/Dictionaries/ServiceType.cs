using KnoKoFin.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class ServiceType : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private ServiceType() { }

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
