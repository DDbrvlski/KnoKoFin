namespace KnoKoFin.API.Middleware.Exceptions
{
    public class NotFoundException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }
        public NotFoundException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }
        public NotFoundException(string message, IDictionary<string, string[]> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
