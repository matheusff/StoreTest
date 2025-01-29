using ActDigital.Store.Sales.Application.ViewModels;
using ActDigital.Store.Sales.Domain;
using AutoMapper;

namespace ActDigital.Store.Sales.Application.AutoMapper;

public class DomainToViewModelProfile : Profile
{
    public DomainToViewModelProfile()
    {
        CreateMap<ProductItem, ProductViewModel>().ReverseMap();
        CreateMap<Sale, SaleViewModel>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Items))
            .ReverseMap();
    }
}