using System.ComponentModel.DataAnnotations;

namespace KnoKoFin.Domain.Enums
{
    public enum InvoiceStateTypeEnum
    {
        [Display(Name = "Wystawiona")]
        Issued,

        [Display(Name = "Opłacona")]
        Paid,

        [Display(Name = "Częściowo opłacona")]
        PartiallyPaid,

        [Display(Name = "Wysłana")]
        Sent
    }
}
