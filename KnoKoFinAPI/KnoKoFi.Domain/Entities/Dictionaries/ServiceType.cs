using KnoKoFin.Domain.Helpers;
using KnoKoFin.Infrastructure.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KnoKoFin.Domain.Entities.Dictionaries
{
    [Table("service_type", Schema = "dictionaries")]
    public class ServiceType : BaseModel
    {

        [Required]
        [Column("NAME", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Name { get; set; }


        [Required]
        [Column("DESCRIPTION", TypeName = "varchar(500)")]
        [MaxLength(500)]
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
