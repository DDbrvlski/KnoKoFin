﻿using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Shared.Dtos;
using KnoKoFin.Infrastructure.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.ServiceTypes
{
    public interface IServiceTypeRepository : IGenericRepository<ServiceType>
    {
        Task<List<ServiceTypeDto>> GetAllServiceTypesAsync();
    }
}
