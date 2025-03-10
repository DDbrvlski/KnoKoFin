using KnoKoFin.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Validators
{
    public static class CountryValidator
    {
        private static readonly Lazy<List<string>> _cachedCountries = new(GetAllValidCountryValues);
        private static CountryInfoAttribute GetCountryInfo(EuropeanCountry country)
        {
            var field = country.GetType().GetField(country.ToString());
            return (CountryInfoAttribute)Attribute.GetCustomAttribute(field, typeof(CountryInfoAttribute));
        }
        public static bool IsValidCountry(string countryInput)
        {
            return _cachedCountries.Value.Contains(countryInput.Trim(), StringComparer.OrdinalIgnoreCase);
        }
        private static List<string> GetAllValidCountryValues()
        {
            var values = new List<string>();

            foreach (EuropeanCountry country in Enum.GetValues(typeof(EuropeanCountry)))
            {
                var attribute = GetCountryInfo(country);
                values.Add(attribute.PolishName);
                values.Add(attribute.EnglishName);
                values.Add(attribute.IsoCode);
            }

            return values.Distinct().ToList();
        }
    }
}
