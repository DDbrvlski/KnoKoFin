using KnoKoFin.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.UpdateServiceType
{
    public class UpdateServiceTypeCommandHandler : IRequestHandler<UpdateServiceTypeCommand, UpdateServiceTypeCommand>
    {
        private readonly ILogger<UpdateServiceTypeCommandHandler> _logger;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly UpdateServiceTypeCommandMapper _mapper;
        public UpdateServiceTypeCommandHandler
            (ILogger<UpdateServiceTypeCommandHandler> logger,
            IServiceTypeRepository serviceTypeRepository,
            UpdateServiceTypeCommandMapper mapper)
        {
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
            _mapper = mapper;
        }

        public async Task<UpdateServiceTypeCommand> Handle(UpdateServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var serviceType = await _serviceTypeRepository.GetByIdAsync(request.Id);
            var updatedServiceType = _mapper.Map(serviceType, request);

            await _serviceTypeRepository.UpdateAsync(updatedServiceType, cancellationToken);
            return _mapper.Map(updatedServiceType);
        }
    }
}
