using AutoMapper;
using Market.Application.Common.Mappings;
using Market.Domain;

namespace Market.Application.Products.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(productDto => productDto.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(productDto => productDto.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(productDto => productDto.Description,
                    opt => opt.MapFrom(product => product.Description))
                .ForMember(productDto => productDto.Price,
                    opt => opt.MapFrom(product => product.Price));
        }
    }
}
