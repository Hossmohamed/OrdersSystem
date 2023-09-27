using AutoMapper;
using OrderUpdate.DTO;
using OrderUpdate.Models;

namespace order
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Orders, OrderDTO>()
           .ForMember(dest => dest.subOrder, opt => opt.MapFrom(src => src.SubOrders))
           .ForMember(dest => dest.OrderID, opt => opt.MapFrom(src => src.ID == 1))
            .ForMember(dest => dest.OrderID, op => op.MapFrom(src => src.ID)).ReverseMap();



            CreateMap<SubOrders, SubOrderDTO>()
                .ForMember(dest => dest.ExecutedQuantity, s => s.MapFrom(src => src.SuborderQuantity / 2))
                .ForMember(dest => dest.SuborderId, opt => opt.MapFrom(src => src.SuborderID == 1))
                .ReverseMap();

        }
    }
}
