using System.ComponentModel.DataAnnotations;

namespace KnoKoFin.Domain.Enums
{
    public enum ContractorTypeEnum
    {
        [Display(Name = "Wewnętrzny")]
        Internal,

        [Display(Name = "Zewnętrzny")]
        External
    }
}
