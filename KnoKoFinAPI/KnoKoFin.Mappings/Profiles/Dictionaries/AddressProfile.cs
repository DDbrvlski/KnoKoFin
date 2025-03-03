using AutoMapper;
using KnoKoFin.Database.Models.Dictionaries;
using KnoKoFin.DTOs.Dictionaries.Addresses;

namespace KnoKoFin.Mappings.Profiles.Dictionaries
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDTO, Address>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street.Trim()))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.PostCode.Replace(" ", "")))

                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<UpdateAddressDTO, Address>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.RowVersion, opt => opt.MapFrom(src => src.RowVersion))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street.Trim()))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.PostCode.Replace(" ", "")))

                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Address, GetAddressDetailsDTO>();
        }
    }

}
