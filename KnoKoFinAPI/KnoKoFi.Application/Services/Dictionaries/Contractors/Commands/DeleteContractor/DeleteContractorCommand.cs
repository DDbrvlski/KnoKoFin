using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommand : IRequest
    {
        public long Id { get; set; }
    }
}
