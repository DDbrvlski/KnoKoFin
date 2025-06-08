using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.Revenues.Interfaces;
using KnoKoFin.Domain.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Revenues.Commands.DeleteRevenue
{
    public class DeleteRevenueCommandHandler : IRequestHandler<DeleteRevenueCommand>
    {
        private readonly IRevenueAppService _revenueAppService;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteRevenueCommandHandler(IRevenueAppService revenueAppService, IUnitOfWork unitOfWork)
        {
            _revenueAppService = revenueAppService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRevenueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _revenueAppService.ArchiveRevenueAsync(request, cancellationToken);

                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new DeleteFailureException($"Wystąpił błąd podczas usuwania wydatku");
            }
        }
    }
}
