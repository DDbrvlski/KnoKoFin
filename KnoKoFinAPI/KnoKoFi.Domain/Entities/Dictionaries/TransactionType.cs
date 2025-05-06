using KnoKoFin.Domain.Enums;
using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class TransactionType : BaseModel
    {
        public string Name { get; set; }
        public TransactionTypeEnum Type { get; set; }
    }
}
