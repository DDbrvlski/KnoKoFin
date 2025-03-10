namespace KnoKoFin.API.Middleware.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }
        public UnauthorizedException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }
        public UnauthorizedException(string message, IDictionary<string, string[]> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
