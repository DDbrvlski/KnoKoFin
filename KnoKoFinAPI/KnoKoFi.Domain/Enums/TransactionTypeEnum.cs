using System.ComponentModel.DataAnnotations;

namespace KnoKoFin.Domain.Enums
{
    public enum TransactionTypeEnum
    {
        [Display(Name = "Przychód")]
        Revenue,
        [Display(Name = "Wydatek")]
        Expense
    }
}
