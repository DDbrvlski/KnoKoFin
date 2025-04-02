using KnoKoFin.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnoKoFin.Infrastructure.Persistence
{
    public class DatabaseOperationHandler
    {
        public static async Task HandleDatabaseOperation(Func<Task> databaseOperation, string operationName)
        {
            try
            {
                await databaseOperation.Invoke();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseOperationException($"Błąd podczas operacji {operationName} w bazie danych.", ex);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"Nieoczekiwany błąd podczas operacji {operationName}.", ex);
            }
        }

    public static async Task<IActionResult> TryToSaveChangesAsync(KnoKoFinContext context, CancellationToken cancellationToken)
        {
            try
            {
                await HandleDatabaseOperation(
                    async () => await context.SaveChangesAsync(cancellationToken),
                    "zapisu danych w bazie"
                );
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"Błąd operacji w bazie danych: {ex.Message}", ex);
            }
        }

    }
}
