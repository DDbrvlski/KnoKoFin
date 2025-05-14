using System.ComponentModel.DataAnnotations;

namespace KnoKoFin.Domain.Enums
{
    public enum InvoiceKindTypeEnum
    {
        [Display(Name = "Faktura")]
        Invoice,

        [Display(Name = "Faktura Proforma")]
        ProformaInvoice,

        [Display(Name = "Nota korygująca")]
        CorrectionNote
    }
}
