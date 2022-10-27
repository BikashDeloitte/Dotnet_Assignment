using AutoMapper;
using OutBoundService.DbContexts;
using OutBoundService.Models.Dto;
using OutBoundService.Models;
using OutBoundService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace OutBoundService.Repository
{
    public class TruckRepository: ITruckRepository
    {
        private readonly OutBoundServiceDbContext _dbContext;
        private IMapper _mapper;

        public TruckRepository(OutBoundServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TruckDto> CreateUpdateTruck(TruckDto truckDto)
        {
            Truck truck = _mapper.Map<TruckDto, Truck>(truckDto);

            if (truck.TruckId > 0)
            {
                _dbContext.Trucks.Update(truck);
            }
            else
            {
                _dbContext.Trucks.Add(truck);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Truck, TruckDto>(truck);
        }

        public async Task<bool> DeleteTruck(int truckId)
        {
            Truck truck = await _dbContext.Trucks.Where(x => x.TruckId == truckId).FirstOrDefaultAsync();
            if (truckId == null)
            {
                return false;
            }
            _dbContext.Remove(truck);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TruckDto> GetTruckById(int truckId)
        {
            Truck truck = await _dbContext.Trucks.Where(x => x.TruckId == truckId).FirstOrDefaultAsync();
            return _mapper.Map<Truck, TruckDto>(truck);
        }

        public async Task<IList<TruckDto>> GetAllTruck()
        {
            IList<Truck> truckList = await _dbContext.Trucks.ToListAsync();
            return _mapper.Map<IList<TruckDto>>(truckList);
        }

    }
}
