using AutoMapper;
using CameraServicesPlatform.BackEnd.Common.DTO.Request;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Domain.Models;



namespace CameraServicesPlatform.BackEnd.Infrastructure.Mapping;

public class MappingConfig
{
    public static MapperConfiguration RegisterMap()
    {
        MapperConfiguration mappingConfig = new(config =>
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
            _ = config.CreateMap<CreateOrderBuyRequest, Order>();
            _ = config.CreateMap<CreateOrderRentRequest, Order>();

            ///Mapper OrderDetail

            config.CreateMap<OrderDetailRequest, OrderDetail>();
            ///Mapper Rating
            config.CreateMap<RatingRequest, Rating>();
            config.CreateMap<Rating, RatingResponse>();

            config.CreateMap<CreateStaffDTO, Staff>()
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.StaffStatus, opt => opt.MapFrom(src => src.StaffStatus))
                .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate))
                .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin))
                .ForMember(dest => dest.Img, opt => opt.MapFrom(src => src.Img));
            ; 
            config.CreateMap<CreateStaffDTO, Account>()
     .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email)) 
    .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.Name))  
     .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))  
    .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false)) 
    .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => false))  
    .ForMember(dest => dest.StaffID, opt => opt.Ignore()); // Assuming this is managed elsewhere

        });
        // Trong class MappingConfig

        return mappingConfig;
    }
}