﻿using KnoKoFin.Application.Common.Exceptions;
using KnoKoFin.Infrastructure.Persistence;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses;
using MediatR;

namespace KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<long>
    {
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
