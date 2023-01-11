using Market.Application.Common.Mappings;
using Market.Domain;
using AutoMapper;

namespace Market.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsVm : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
                
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVm>()
                .ForMember(productVm => productVm.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.UserId,
                    opt => opt.MapFrom(productVm => productVm.UserId))
                .ForMember(productVm => productVm.Name,
                    opt => opt.MapFrom(productVm => productVm.Name))
                .ForMember(productVm => productVm.Description,
                    opt => opt.MapFrom(productVm => productVm.Description))
                .ForMember(productVm => productVm.Price,
                    opt => opt.MapFrom(productVm => productVm.Price));
        }
    }
}
