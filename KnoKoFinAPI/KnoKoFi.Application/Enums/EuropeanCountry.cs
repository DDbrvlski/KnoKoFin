using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Enums
{
    public enum EuropeanCountry
    {
        [CountryInfo("Albania", "AL", "Albania")]
        Albania,

        [CountryInfo("Andora", "AD", "Andorra")]
        Andorra,

        [CountryInfo("Armenia", "AM", "Armenia")]
        Armenia,

        [CountryInfo("Austria", "AT", "Austria")]
        Austria,

        [CountryInfo("Azerbejdżan", "AZ", "Azerbaijan")]
        Azerbaijan,

        [CountryInfo("Belgia", "BE", "Belgium")]
        Belgium,

        [CountryInfo("Białoruś", "BY", "Belarus")]
        Belarus,

        [CountryInfo("Bośnia i Hercegowina", "BA", "Bosnia and Herzegovina")]
        BosniaHerzegovina,

        [CountryInfo("Bułgaria", "BG", "Bulgaria")]
        Bulgaria,

        [CountryInfo("Chorwacja", "HR", "Croatia")]
        Croatia,

        [CountryInfo("Cypr", "CY", "Cyprus")]
        Cyprus,

        [CountryInfo("Czarnogóra", "ME", "Montenegro")]
        Montenegro,

        [CountryInfo("Czechy", "CZ", "Czech Republic")]
        CzechRepublic,

        [CountryInfo("Dania", "DK", "Denmark")]
        Denmark,

        [CountryInfo("Estonia", "EE", "Estonia")]
        Estonia,

        [CountryInfo("Finlandia", "FI", "Finland")]
        Finland,

        [CountryInfo("Francja", "FR", "France")]
        France,

        [CountryInfo("Grecja", "GR", "Greece")]
        Greece,

        [CountryInfo("Gruzja", "GE", "Georgia")]
        Georgia,

        [CountryInfo("Hiszpania", "ES", "Spain")]
        Spain,

        [CountryInfo("Holandia", "NL", "Netherlands")]
        Netherlands,

        [CountryInfo("Irlandia", "IE", "Ireland")]
        Ireland,

        [CountryInfo("Islandia", "IS", "Iceland")]
        Iceland,

        [CountryInfo("Kazachstan", "KZ", "Kazakhstan")]
        Kazakhstan,

        [CountryInfo("Kosowo", "XK", "Kosovo")]
        Kosovo,

        [CountryInfo("Liechtenstein", "LI", "Liechtenstein")]
        Liechtenstein,

        [CountryInfo("Litwa", "LT", "Lithuania")]
        Lithuania,

        [CountryInfo("Luksemburg", "LU", "Luxembourg")]
        Luxembourg,

        [CountryInfo("Łotwa", "LV", "Latvia")]
        Latvia,

        [CountryInfo("Macedonia Północna", "MK", "North Macedonia")]
        NorthMacedonia,

        [CountryInfo("Malta", "MT", "Malta")]
        Malta,

        [CountryInfo("Mołdawia", "MD", "Moldova")]
        Moldova,

        [CountryInfo("Monako", "MC", "Monaco")]
        Monaco,

        [CountryInfo("Niemcy", "DE", "Germany")]
        Germany,

        [CountryInfo("Norwegia", "NO", "Norway")]
        Norway,

        [CountryInfo("Polska", "PL", "Poland")]
        Poland,

        [CountryInfo("Portugalia", "PT", "Portugal")]
        Portugal,

        [CountryInfo("Rosja", "RU", "Russia")]
        Russia,

        [CountryInfo("Rumunia", "RO", "Romania")]
        Romania,

        [CountryInfo("San Marino", "SM", "San Marino")]
        SanMarino,

        [CountryInfo("Serbia", "RS", "Serbia")]
        Serbia,

        [CountryInfo("Słowacja", "SK", "Slovakia")]
        Slovakia,

        [CountryInfo("Słowenia", "SI", "Slovenia")]
        Slovenia,

        [CountryInfo("Szwajcaria", "CH", "Switzerland")]
        Switzerland,

        [CountryInfo("Szwecja", "SE", "Sweden")]
        Sweden,

        [CountryInfo("Turcja", "TR", "Turkey")]
        Turkey,

        [CountryInfo("Ukraina", "UA", "Ukraine")]
        Ukraine,

        [CountryInfo("Watykan", "VA", "Holy See")]
        Vatican,

        [CountryInfo("Węgry", "HU", "Hungary")]
        Hungary,

        [CountryInfo("Wielka Brytania", "GB", "United Kingdom")]
        UnitedKingdom,

        [CountryInfo("Włochy", "IT", "Italy")]
        Italy
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class CountryInfoAttribute : Attribute
    {
        public string EnglishName { get; }
        public string IsoCode { get; }
        public string PolishName { get; }

        public CountryInfoAttribute(string englishName, string isoCode, string polishName)
        {
            EnglishName = englishName;
            IsoCode = isoCode;
            PolishName = polishName;
        }
    }

}
