using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Application.Services.Billings.Revenues.Interfaces;
using KnoKoFin.Domain.Entities.Billings;
using KnoKoFin.Domain.Interfaces;
using KnoKoFin.Domain.Interfaces.Repositories.Billings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Application.Services.Billings.Revenues.Commands.CreateRevenue
{
    public class CreateRevenueCommandHandler : IRequestHandler<CreateRevenueCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRevenueAppService _revenueAppService;
        public CreateRevenueCommandHandler(IUnitOfWork unitOfWork, IRevenueAppService revenueAppService)
        {
            _unitOfWork = unitOfWork;
            _revenueAppService = revenueAppService;
        }
        public async Task<long> Handle(CreateRevenueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var addedRevenue = await _revenueAppService.CreateRevenueAsync(request, cancellationToken);

                await _unitOfWork.CommitTransactionAsync();

                return addedRevenue.Id;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new CreateFailureException(nameof(Expense), request, $"Wystąpił błąd podczas tworzenia: {ex.Message}");
            }
        }
    }
}
