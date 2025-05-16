using KnoKoFin.Application.DTOs.Dictionaries.Addresses;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorDetails;
using KnoKoFin.Application.Services.Dictionaries.Contractors.Queries.GetContractorList;
using KnoKoFin.Domain.Entities.Dictionaries;
using KnoKoFin.Domain.Interfaces.Repositories;
using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KnoKoFin.Infrastructure.Repositories.Dictionaries.Contractors
{
    public class DictionaryContractorRepository : 
        GenericRepository<DictionaryContractor>, 
        IDictionaryContractorRepository, 
        IGetContractorDetailsRepository,
        IGetContractorListRepository
    {
        public DictionaryContractorRepository(KnoKoFinContext context, ILogger<GenericRepository<DictionaryContractor>> logger)
            : base(context, logger) { }

        public async Task<GetContractorAddressIdDto?> GetContractorAddressId(long contractorId)
        {
            return await _dbSet.Where(x => x.Id == contractorId)
                .Select(x => new GetContractorAddressIdDto()
                {
                    ContractorId = x.Id,
                    AddressId = x.AddressId
                }).FirstOrDefaultAsync();
        }

        public async Task<ContractorDetailsDto> GetContractorDetails(long id, CancellationToken cancellationToken)
        {
            var contractor = await GetSingle(id).Select(x => new ContractorDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                Fax = x.Fax,
                Nip = x.Nip,
                Description = x.Description,
                Swift = x.Swift,
                BankName = x.BankName,
                BankAccountNumber = x.BankAccountNumber,
                ContractorType = x.ContractorType,
                FirstName = x.FirstName,
                PhoneNumber = x.PhoneNumber,
                Address = new AddressDetailsDTO()
                {
                    Id = x.Address.Id,
                    Street = x.Address.Street,
                    City = x.Address.City,
                    Country = x.Address.Country,
                    PostCode = x.Address.PostCode,
                    RowVersion = x.Address.RowVersion,
                }

            }).FirstOrDefaultAsync(cancellationToken);

            return contractor;
        }

        public async Task<ContractorList> GetContractorList(CancellationToken cancellationToken)
        {
            var items = await GetAll().Select(x => new ContractorDto()
            {
                Id = x.Id,
                Name = x.Name,
                ContractorType = x.ContractorType,
                FullName = $"{x.FirstName} {x.LastName}"
            }).ToListAsync(cancellationToken);

            return new ContractorList() { Contractors = items };
        }
    }
}
