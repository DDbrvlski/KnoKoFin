using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class TransactionType : BaseModel
    {
        public string Name { get; set; }
        public TransactionTypeEnum Type { get; set; }
    }
}
