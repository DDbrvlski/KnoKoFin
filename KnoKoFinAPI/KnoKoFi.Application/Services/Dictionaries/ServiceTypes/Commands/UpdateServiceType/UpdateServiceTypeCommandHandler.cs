using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType
{
    public class UpdateServiceTypeCommandHandler : IRequestHandler<UpdateServiceTypeCommand, UpdateServiceTypeCommand>
    {
        private readonly ILogger<UpdateServiceTypeCommandHandler> _logger;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        public UpdateServiceTypeCommandHandler
            (ILogger<UpdateServiceTypeCommandHandler> logger,
            IServiceTypeRepository serviceTypeRepository)
        {
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<UpdateServiceTypeCommand> Handle(UpdateServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var serviceType = await _serviceTypeRepository.GetByIdAsync(request.Id, cancellationToken);
            var updatedServiceType = UpdateServiceTypeCommandMapper.ApplyUpdate(serviceType, request);

            await _serviceTypeRepository.UpdateAsync(updatedServiceType, cancellationToken);
            return UpdateServiceTypeCommandMapper.ToCommand(updatedServiceType);
        }
    }
}
