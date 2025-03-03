﻿using KnoKoFin.Database.Models.Dictionaries;

namespace KnoKoFin.API.Repositories.Dictionaries.Addresses
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetByCityAsync(string city);
        Task<IEnumerable<Address>> GetByPostCodeAsync(string postCode);
    }
}
