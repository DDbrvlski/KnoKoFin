﻿using KnoKoFin.Application.DTOs;
using KnoKoFin.Application.DTOs.Dictionaries.Addresses;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Dtos;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Dtos
{
    public class ContractorDetailsDto : BaseDto
    {
        public long Id { get; set; }
        public string? ContractorType { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public string? Nip { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? Fax { get; set; }
        public string? Swift { get; set; }
        public AddressDetailsDto? Address { get; set; }

    }
}
