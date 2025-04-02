using KnoKoFin.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Validators
{
    public static class PostalCodeValidator
    {
        private static readonly Dictionary<string, string> CountryPatterns = new(StringComparer.OrdinalIgnoreCase)
    {
        { "PL", @"^\d{2}-\d{3}$" },
        { "DE", @"^\d{5}$" },
        { "FR", @"^\d{5}$" },
        { "ES", @"^\d{5}$" },
        { "IT", @"^\d{5}$" },
        { "NL", @"^(?i)\d{4}[A-Za-z]{2}$" },
        { "BE", @"^\d{4}$" },
        { "AT", @"^\d{4}$" },
        { "CH", @"^\d{4}$" },
        { "GB", @"^(?i)[A-Z]{1,2}\d[A-Z\d]? \d[A-Z]{2}$" },
        { "DK", @"^\d{4}$" },
        { "SE", @"^\d{3} \d{2}$" },
        { "NO", @"^\d{4}$" },
        { "FI", @"^\d{5}$" },
        { "GR", @"^\d{5}$" },
        { "PT", @"^\d{4}-\d{3}$" },
        { "LT", @"^(?i)(LT-?)?\d{5}$" },
        { "LV", @"^(?i)(LV-?)?\d{4}$" },
        { "EE", @"^\d{5}$" },
        { "CZ", @"^\d{3} \d{2}$" },
        { "SK", @"^\d{3} \d{2}$" },
        { "HU", @"^\d{4}$" },
        { "RO", @"^\d{6}$" },
        { "BG", @"^\d{4}$" },
        { "HR", @"^\d{5}$" },
        { "RS", @"^\d{5}$" },
        { "SI", @"^\d{4}$" },
        { "AL", @"^\d{4}$" },
        { "XK", @"^\d{5}$" },
        { "MK", @"^\d{4}$" },
        { "ME", @"^\d{5}$" },
        { "BA", @"^\d{5}$" },
        { "MT", @"^(?i)[A-Z]{3} \d{4}$" },
        { "IE", @"^[A-Za-z0-9]{7}$" },
        { "IS", @"^\d{3}$" },
        { "LI", @"^(948[5-9]|949[0-7])$" },
        { "MC", @"^980\d{2}$" },
        { "SM", @"^4789\d$" },
        { "VA", @"^00120$" },
        { "AD", @"^AD\d{3}$" },
        { "GL", @"^39\d{2}$" },
        { "GI", @"^GX11 1AA$" },
        { "FO", @"^FO\d{3}$" }
    };

        public static bool IsValidPostalCode(string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(postalCode) || string.IsNullOrWhiteSpace(country))
                return false;

            if (CountryPatterns.TryGetValue(country.ToUpper(), out var pattern))
                return Regex.IsMatch(postalCode, pattern);

            return false;
        }
    }

}
