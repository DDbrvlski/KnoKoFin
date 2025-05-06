namespace KnoKoFin.Infrastructure.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
        public NotFoundException(string name, object key)
            : base($"Encja \"{name}\" ({key}) nie została znaleziona.")
        {
        }
    }
}
