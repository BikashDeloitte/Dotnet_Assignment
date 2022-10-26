using AutoMapper;
using SystemManagement.Models;
using SystemManagement.Models.Dto;

namespace SystemManagement.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>().ReverseMap();
                config.CreateMap<Pallet, PalletDto>().ReverseMap();
                config.CreateMap<Node, NodeDto>().ReverseMap();
                config.CreateMap<LPN,LPNDto>().ReverseMap();
                config.CreateMap<Warehouse, WarehouseDto>().ReverseMap();   
            });

            return mappingConfig;
        }
    }
}
