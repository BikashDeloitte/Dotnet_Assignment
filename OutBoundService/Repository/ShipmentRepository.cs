using AutoMapper;
using OutBoundService.DbContexts;
using OutBoundService.Models.Dto;
using OutBoundService.Models;
using OutBoundService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace OutBoundService.Repository
{
    public class ShipmentRepository:IShipmentRepository
    {
        private readonly OutBoundServiceDbContext _dbContext;
        private IMapper _mapper;

        public ShipmentRepository(OutBoundServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ShipmentDto> CreateUpdateShipment(ShipmentDto shipmentDto)
        {
            Shipment shipment = _mapper.Map<ShipmentDto, Shipment>(shipmentDto);

            if (shipment.ShipmentId > 0)
            {
                _dbContext.Shipments.Update(shipment);
            }
            else
            {
                _dbContext.Shipments.Add(shipment);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Shipment, ShipmentDto>(shipment);
        }

        public async Task<bool> DeleteShipment(int shipmentId)
        {
            Shipment shipment = await _dbContext.Shipments.Where(x => x.ShipmentId == shipmentId).FirstOrDefaultAsync();
            if (shipmentId == null)
            {
                return false;
            }
            _dbContext.Remove(shipment);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ShipmentDto> GetShipmentById(int shipmentId)
        {
            Shipment shipment = await _dbContext.Shipments.Where(x => x.ShipmentId == shipmentId).FirstOrDefaultAsync();
            return _mapper.Map<Shipment, ShipmentDto>(shipment);
        }

        public async Task<IList<ShipmentDto>> GetAllShipment()
        {
            IList<Shipment> shipmentList = await _dbContext.Shipments.ToListAsync();
            return _mapper.Map<IList<ShipmentDto>>(shipmentList);
        }

        public async Task<ShipmentDto> ShipmentStatus(int id, string status)
        {
            Shipment shipment = await _dbContext.Shipments.Where(x => x.ShipmentId == id).FirstOrDefaultAsync();
            shipment.ShipmentStatus = status;
            _dbContext.Shipments.Update(shipment);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Shipment, ShipmentDto>(shipment);
        }
    }
}
