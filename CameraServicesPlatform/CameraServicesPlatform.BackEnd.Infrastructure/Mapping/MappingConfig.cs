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
            config.CreateMap<CreateOrderBuyRequest, Order>();
            config.CreateMap<CreateOrderRentRequest, Order>();
            config.CreateMap<Order, OrderResponse>();

            ///Mapper OrderDetail

            config.CreateMap<OrderDetailRequest, OrderDetail>();
            config.CreateMap<OrderDetail, OrderDetailResponse>();
            ///Mapper Rating
            config.CreateMap<RatingRequest, Rating>();
            config.CreateMap<Rating, RatingResponse>();
            config.CreateMap<Contract, ContractResponse>();
            config.CreateMap<ContractTemplate, ContractTemplateResponse>();
            config.CreateMap<Policy, PolicyResponse>();
            config.CreateMap<Report, ReportResponse>();
            config.CreateMap<ReturnDetail, ReturnDetailResponse>();
            config.CreateMap<Wishlist, WishlistResponse>();



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
 
               //WishList
            config.CreateMap<CreateWishlistRequestDTO, Wishlist>();
            //ReturnDetal
            config.CreateMap<ReturnDetailRequest, ReturnDetail>();
            //Policy
            config.CreateMap<PolicyRequestDTO, Policy>();



            // Map from CreateSupplierRequest to Account
            config.CreateMap<CreateSupplierAccountDTO, Account>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
             .ForMember(dest => dest.SupplierID, opt => opt.Ignore()); // Ignore if you want to set it manually

            config.CreateMap<CreateSupplierAccountDTO, Supplier>()
                .ForMember(dest => dest.AccountID, opt => opt.Ignore()) // This will be set after creating the Account
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            config.CreateMap<CreateSupplierAccountDTO, BankInformation>()
               .ForMember(dest => dest.AccountID, opt => opt.Ignore()); // This will be set after creating the Account
               


        });
        // Trong class MappingConfig

        return mappingConfig;
    }
}