using AutoMapper;
using CameraServicesPlatform.BackEnd.Domain.Models;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;


namespace CameraServicesPlatform.BackEnd.Infrastructure.Mapping;

public class MappingConfig
{
    public static MapperConfiguration RegisterMap()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            //aCCOUNT
            config.CreateMap<Account, AccountResponse>()
               .ForMember(desc => desc.Id, act => act.MapFrom(src => src.Id))
               .ForMember(desc => desc.Email, act => act.MapFrom(src => src.Email))
               .ForMember(desc => desc.Gender, act => act.MapFrom(src => src.Gender))
               .ForMember(desc => desc.IsVerified, act => act.MapFrom(src => src.IsVerified))
               .ForMember(desc => desc.FirstName, act => act.MapFrom(src => src.FirstName))
               .ForMember(desc => desc.LastName, act => act.MapFrom(src => src.LastName))
               .ForMember(desc => desc.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))
               .ForMember(desc => desc.UserName, act => act.MapFrom(src => src.UserName));

            ///Mapper Order
            config.CreateMap<CreateOrderBuyRequest, Order>();
            ///Mapper OrderDetail
            config.CreateMap<OrderDetailRequest, OrderDetail>();
        });
        // Trong class MappingConfig
        
        return mappingConfig;
    }
}