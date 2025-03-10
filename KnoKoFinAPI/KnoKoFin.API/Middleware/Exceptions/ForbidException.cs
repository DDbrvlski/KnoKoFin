namespace KnoKoFin.API.Middleware.Exceptions
{
    public class ForbidException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }
        public ForbidException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ForbidException(string message, IDictionary<string, string[]> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
