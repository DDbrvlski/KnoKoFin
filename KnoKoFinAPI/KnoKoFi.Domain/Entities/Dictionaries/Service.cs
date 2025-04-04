using KnoKoFin.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Domain.Entities.Dictionaries
{
    public class Service : BaseModel
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

        private Service() { }

        public static Service Create
            (string name, 
            string description, 
            decimal? discount, 
            decimal? netPrice, 
            decimal? grossPrice, 
            decimal? vat, 
            string unit, 
            int? quantity)
        {
            return new Service
            {
                Name = name,
                Description = description,
                Discount = discount,
                NetPrice = netPrice,
                GrossPrice = grossPrice,
                Vat = vat,
                Unit = unit,
                Quantity = quantity
            };
        }

        public void Update
            (string name, 
            string description, 
            decimal? discount, 
            decimal? netPrice, 
            decimal? grossPrice, 
            decimal? vat, 
            string unit, 
            int? quantity)
        {
            Name = name;
            Description = description;
            Discount = discount;
            NetPrice = netPrice;
            GrossPrice = grossPrice;
            Vat = vat;
            Unit = unit;
            Quantity = quantity;
        }
    }
}
