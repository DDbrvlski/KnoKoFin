using KnoKoFin.Domain.Helpers;

namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class DictionaryService : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Archival { get; set; } = false;
        public decimal? Discount { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? GrossPrice { get; set; }
        public decimal? Vat { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
    }
}
