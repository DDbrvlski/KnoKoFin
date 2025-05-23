﻿using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace InvoiceGenerator.Generators.QuestPDF.Invoices.InvoiceComponents
{
    public class PaymentDetailsComponent : IComponent
    {
        private string PaymentMethodTitle { get; }
        private string PaymentCurrencyTitle { get; }
        private DateTime PaymentDate { get; }
        private string DeliveryMethodTitle { get; }
        private decimal DeliveryPrice { get; }

        public PaymentDetailsComponent(string paymentMethodTitle, DateTime? paymentDate, string deliveryMethodTitle, string currencyName, decimal deliveryPrice)
        {
            if (paymentDate == null)
            {
                //throw new BadRequestException("Wystąpił błąd podczas generowania faktury");
            }
            PaymentMethodTitle = paymentMethodTitle;
            DeliveryMethodTitle = deliveryMethodTitle;
            PaymentDate = (DateTime)paymentDate;
            PaymentCurrencyTitle = currencyName;
            DeliveryPrice = deliveryPrice;
        }

        public void Compose(IContainer container)
        {
            var textStyle = TextStyle.Default.FontFamily(Fonts.Arial);
            container.Column(column =>
            {
                column.Spacing(2);

                column.Item().Row(row =>
                {
                    row.RelativeItem().AlignRight().Text("Forma płatności:").Style(textStyle);
                    row.ConstantItem(5);
                    row.RelativeItem().Text($"{PaymentMethodTitle}").Style(textStyle);
                });
                column.Item().Row(row =>
                {
                    row.RelativeItem().AlignRight().Text("Waluta:").Style(textStyle);
                    row.ConstantItem(5);
                    row.RelativeItem().Text($"{PaymentCurrencyTitle}").Style(textStyle);
                });
                column.Item().Row(row =>
                {
                    row.RelativeItem().AlignRight().Text("Data płatności:").Style(textStyle);
                    row.ConstantItem(5);
                    row.RelativeItem().Text($"{PaymentDate.ToShortDateString()}").Style(textStyle);
                });
                column.Item().Row(row =>
                {
                    row.RelativeItem().AlignRight().Text("Sposób dostawy:").Style(textStyle);
                    row.ConstantItem(5);
                    row.RelativeItem().Text($"{DeliveryMethodTitle}").Style(textStyle);
                });
                column.Item().Row(row =>
                {
                    row.RelativeItem().AlignRight().Text("Koszt dostawy:").Style(textStyle);
                    row.ConstantItem(5);
                    row.RelativeItem().Text($"{DeliveryPrice}").Style(textStyle);
                });
            });
        }
    }
}
