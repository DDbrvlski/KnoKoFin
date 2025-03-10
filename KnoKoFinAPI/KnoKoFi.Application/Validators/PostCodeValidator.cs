using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Validators
{
    public static class PostCodeValidator
    {
        public static bool IsValidPostalCodeForCountry(string postalCode, string country)
        {
            return country.ToUpper() switch
            {
                "POLSKA" or "PL" => Regex.IsMatch(postalCode, @"^\d{2}-\d{3}$"),
                "NIEMCY" or "DE" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "FRANCJA" or "FR" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "HISZPANIA" or "ES" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "WŁOCHY" or "IT" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "HOLANDIA" or "NL" => Regex.IsMatch(postalCode, @"^(?i)\d{4}[A-Za-z]{2}$"),
                "BELGIA" or "BE" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "AUSTRIA" or "AT" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "SZWAJCARIA" or "CH" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "WIELKA BRYTANIA" or "GB" => Regex.IsMatch(postalCode, @"^(?i)[A-Z]{1,2}\d[A-Z\d]? \d[A-Z]{2}$"),
                "ANGLIA" or "GB" => Regex.IsMatch(postalCode, @"^(?i)[A-Z]{1,2}\d[A-Z\d]? \d[A-Z]{2}$"),
                "DANIA" or "DK" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "SZWECJA" or "SE" => Regex.IsMatch(postalCode, @"^\d{3} \d{2}$"),
                "NORWEGIA" or "NO" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "FINLANDIA" or "FI" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "GRECJA" or "GR" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "PORTUGALIA" or "PT" => Regex.IsMatch(postalCode, @"^\d{4}-\d{3}$"),
                "LITWA" or "LT" => Regex.IsMatch(postalCode, @"^(?i)(LT-?)?\d{5}$"),
                "ŁOTWA" or "LV" => Regex.IsMatch(postalCode, @"^(?i)(LV-?)?\d{4}$"),
                "ESTONIA" or "EE" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "CZECHY" or "CZ" => Regex.IsMatch(postalCode, @"^\d{3} \d{2}$"),
                "SŁOWACJA" or "SK" => Regex.IsMatch(postalCode, @"^\d{3} \d{2}$"),
                "WĘGRY" or "HU" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "RUMUNIA" or "RO" => Regex.IsMatch(postalCode, @"^\d{6}$"),
                "BUŁGARIA" or "BG" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "CHORWACJA" or "HR" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "SERBIA" or "RS" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "SŁOWENIA" or "SI" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "ALBANIA" or "AL" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "KOSOWO" or "XK" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "MACEDONIA" or "MK" => Regex.IsMatch(postalCode, @"^\d{4}$"),
                "CZARNOGÓRA" or "ME" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "BOŚNIA I HERCEGOWINA" or "BA" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                "MALTA" or "MT" => Regex.IsMatch(postalCode, @"^(?i)[A-Z]{3} \d{4}$"),
                "IRLANDIA" or "IE" => Regex.IsMatch(postalCode, @"^[A-Za-z0-9]{7}$"),
                "ISLANDIA" or "IS" => Regex.IsMatch(postalCode, @"^\d{3}$"),
                "LIECHTENSTEIN" or "LI" => Regex.IsMatch(postalCode, @"^(948[5-9]|949[0-7])$"),
                "MONAKO" or "MC" => Regex.IsMatch(postalCode, @"^980\d{2}$"),
                "SAN MARINO" or "SM" => Regex.IsMatch(postalCode, @"^4789\d$"),
                "WATYKAN" or "VA" => Regex.IsMatch(postalCode, @"^00120$"),
                "ANDORA" or "AD" => Regex.IsMatch(postalCode, @"^AD\d{3}$"),
                "GRENLANDIA" or "GL" => Regex.IsMatch(postalCode, @"^39\d{2}$"),
                "GIBRALTAR" or "GI" => Regex.IsMatch(postalCode, @"^GX11 1AA$"),
                "WYSPY OWCZE" or "FO" => Regex.IsMatch(postalCode, @"^FO\d{3}$"),

                _ => !string.IsNullOrWhiteSpace(postalCode)
            };
        }
    }
}
