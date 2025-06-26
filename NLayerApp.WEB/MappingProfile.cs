using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDTO, UserViewModel>().ReverseMap();
        CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
    }
}