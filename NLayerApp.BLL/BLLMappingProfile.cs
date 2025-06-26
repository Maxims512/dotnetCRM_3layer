// BLLMappingProfile.cs
using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.DAL.Entities;

public class BLLMappingProfile : Profile
{
    public BLLMappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
    }
}