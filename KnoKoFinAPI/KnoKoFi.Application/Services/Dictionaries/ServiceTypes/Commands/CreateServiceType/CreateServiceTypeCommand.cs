﻿using KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Dto;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.ServiceTypes.Commands.CreateServiceType
{
    public class CreateServiceTypeCommand : IRequest<CreateServiceTypeResultDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
