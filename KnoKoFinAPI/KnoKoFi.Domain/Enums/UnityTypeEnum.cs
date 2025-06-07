using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Domain.Enums
{
    public enum UnityTypeEnum
    {
        [Display(Name = "szt.")]
        Piece,

        [Display(Name = "kg")]
        Kilogram,

        [Display(Name = "g")]
        Gram,

        [Display(Name = "l")]
        Liter,

        [Display(Name = "ml")]
        Milliliter,

        [Display(Name = "m")]
        Meter,

        [Display(Name = "cm")]
        Centimeter,

        [Display(Name = "mm")]
        Millimeter,

        [Display(Name = "h")]
        Hour,

        [Display(Name = "min")]
        Minute,

        [Display(Name = "sek")]
        Second,

        [Display(Name = "opak.")]
        Package,

        [Display(Name = "mb")]
        RunningMeter,

        [Display(Name = "kWh")]
        KilowattHour,

        [Display(Name = "m2")]
        SquareMeter,

        [Display(Name = "m3")]
        CubicMeter,

        [Display(Name = "dni")]
        Days
    }

}
