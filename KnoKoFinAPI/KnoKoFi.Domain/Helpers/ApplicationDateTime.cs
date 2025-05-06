using KnoKoFin.Domain.Interfaces;

namespace KnoKoFin.Domain.Helpers
{
    public class ApplicationDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
