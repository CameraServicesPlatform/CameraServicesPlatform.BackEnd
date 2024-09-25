using AutoMapper;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;



namespace CameraServicesPlatform.BackEnd.Infrastructure.Mapping;

public class MappingConfig
{
    public static MapperConfiguration RegisterMap()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            //ACCOUNT
            config.CreateMap<Account, AccountResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => src.IsVerified))
             .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
 
            ///Mapper Order
            config.CreateMap<CreateOrderBuyRequest, Order>();
            ///Mapper OrderDetail
            config.CreateMap<OrderDetailRequest, OrderDetail>();
        });
        // Trong class MappingConfig

        return mappingConfig;
    }
}