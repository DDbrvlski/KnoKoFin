namespace KnoKoFin.Domain.Exceptions
{
    public class PostalCodeValidationException : Exception
    {
        public PostalCodeValidationException(string error) : base(error)
        {

        }
    }
}
