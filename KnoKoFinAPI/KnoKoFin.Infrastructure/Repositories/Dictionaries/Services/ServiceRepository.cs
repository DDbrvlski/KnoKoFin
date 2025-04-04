using KnoKoFin.Application.Interfaces.Repositories;
using KnoKoFin.Application.Services.Dictionaries.Services.Commands.UpdateService;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Services
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(KnoKoFinContext context, ILogger<GenericRepository<Service>> logger)
            : base(context, logger) { }

    }
}
