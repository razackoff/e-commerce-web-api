using AutoMapper;
using Market.Application.Common.Mappings;
using Market.Application.Products.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.WebAPI.Models
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(productCommand => productCommand.UserId,
                    opt => opt.MapFrom(productDto => productDto.UserId))
                .ForMember(productCommand => productCommand.Name,
                    opt => opt.MapFrom(productDto => productDto.Name))
                .ForMember(productCommand => productCommand.Description,
                    opt => opt.MapFrom(productDto => productDto.Description))
                .ForMember(productCommand => productCommand.Price,
                    opt => opt.MapFrom(productDto => productDto.Price));
        }
    }
}
