namespace KnoKoFin.Application.Common.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string message) : base(message)
        {

        }
        public DeleteFailureException(string name, object key, string message)
            : base($"Wystąpił problem podczas usuwania encji \"{name}\" ({key}). {message}")
        {
        }
    }
}
