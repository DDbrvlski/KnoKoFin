using KnoKoFin.Application.DTOs.Dictionaries.Addresses;
using KnoKoFin.Domain.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;

namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorDetails
{
    public static class GetContractorDetailsQueryMapper
    {
    //    public static async Task<ContractorDetailsDto> GetContractorDetails(IQueryable<DictionaryContractor> query, CancellationToken cancellationToken)
    //    {
    //        var contractor = await query.Select(x => new ContractorDetailsDto()
    //        {
    //            Id = x.Id,
    //            Name = x.Name,
    //            LastName = x.LastName,
    //            Email = x.Email,
    //            Fax = x.Fax,
    //            Nip = x.Nip,
    //            Description = x.Description,
    //            Swift = x.Swift,
    //            BankName = x.BankName,
    //            BankAccountNumber = x.BankAccountNumber,
    //            ContractorType = x.ContractorType,
    //            FirstName = x.FirstName,
    //            PhoneNumber = x.PhoneNumber,
    //            Address = new AddressDetailsDTO()
    //            {
    //                Id = x.Address.Id,
    //                Street = x.Address.Street,
    //                City = x.Address.City,
    //                Country = x.Address.Country,
    //                PostCode = x.Address.PostCode,
    //                RowVersion = x.Address.RowVersion,
    //            }

    //        }).FirstOrDefaultAsync(cancellationToken);

    //        return contractor;
    //    }
    //}
}
