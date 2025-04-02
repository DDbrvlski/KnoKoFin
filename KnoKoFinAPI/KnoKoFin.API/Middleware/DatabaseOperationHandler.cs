using KnoKoFin.API.Middleware.Exceptions;
using KnoKoFin.Infrastructure.Common.Exceptions;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace KnoKoFin.API.Middleware
{
    public class DatabaseOperationHandler
    {
        public static async Task HandleDatabaseOperation(Func<Task> databaseOperation, string operationName)
        {
            try
            {
                await databaseOperation.Invoke();
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"Błąd podczas operacji {operationName} w bazie danych.", ex);
            }
        }

        public static async Task<IActionResult> TryToSaveChangesAsync(KnoKoFinContext context)
        {
            try
            {
                await DatabaseOperationHandler.HandleDatabaseOperation(
                    async () => await context.SaveChangesAsync(),
                    "zapisu danych w bazie");
                return new OkResult();
            }
            catch (DatabaseOperationException ex)
            {
                throw new BadRequestException($"Błąd operacji w bazie danych: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Błąd operacji w bazie danych: {ex.Message}");
            }
        }

    }
}
