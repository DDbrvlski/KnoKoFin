namespace KnoKoFin.Application.Common.Exceptions
{
    public class CreateFailureException : Exception
    {
        public CreateFailureException(string name, object key, string message)
            : base($"Wystąpił problem podczas tworzenia encji \"{name}\" ({key}). {message}") { }
    }
}
