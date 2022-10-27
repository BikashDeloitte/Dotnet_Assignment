using AutoMapper;
using OutBoundService.Models;
using OutBoundService.Models.Dto;

namespace OutBoundService.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomerOrder, CustomerOrderDto>().ReverseMap();
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
                config.CreateMap<Truck, TruckDto>().ReverseMap();
                config.CreateMap<Driver, DriverDto>().ReverseMap();
                config.CreateMap<Shipment, ShipmentDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
