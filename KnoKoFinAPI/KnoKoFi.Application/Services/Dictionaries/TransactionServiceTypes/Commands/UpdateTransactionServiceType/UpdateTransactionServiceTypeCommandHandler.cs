using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dtos;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType
{
    public class UpdateTransactionServiceTypeCommandHandler : IRequestHandler<UpdateTransactionServiceTypeCommand, UpdateTransactionServiceTypeResultDto>
    {
        private readonly ILogger<UpdateTransactionServiceTypeCommandHandler> _logger;
        private readonly ITransactionServiceTypeRepository _serviceTypeRepository;
        public UpdateTransactionServiceTypeCommandHandler
            (ILogger<UpdateTransactionServiceTypeCommandHandler> logger,
            ITransactionServiceTypeRepository serviceTypeRepository)
        {
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<UpdateTransactionServiceTypeResultDto> Handle(UpdateTransactionServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var serviceType = await _serviceTypeRepository.GetByIdAsync(request.Id, cancellationToken);
            var updatedServiceType = UpdateTransactionServiceTypeCommandMapper.ApplyUpdate(serviceType, request);

            await _serviceTypeRepository.UpdateAsync(updatedServiceType, cancellationToken);
            return UpdateTransactionServiceTypeCommandMapper.ServiceTypeToUpdateResultDto(updatedServiceType);
        }
    }
}
