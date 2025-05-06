namespace KnoKoFin.Application.Common.Exceptions
{
    public class UpdateFailureException : Exception
    {
        public UpdateFailureException(string name, object key, string message)
            : base($"Wystąpił problem podczas modyfikowania encji \"{name}\" ({key}). {message}") { }
    }
}
