using AutoMapper;
using OutBoundService.DbContexts;
using OutBoundService.Models.Dto;
using OutBoundService.Models;
using OutBoundService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace OutBoundService.Repository
{
    public class DriverRepository: IDriverRepository
    {
        private readonly OutBoundServiceDbContext _dbContext;
        private IMapper _mapper;

        public DriverRepository(OutBoundServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DriverDto> CreateUpdateDriver(DriverDto driverDto)
        {
            Driver driver = _mapper.Map<DriverDto, Driver>(driverDto);

            if (driver.DriverId > 0)
            {
                _dbContext.Drivers.Update(driver);
            }
            else
            {
                _dbContext.Drivers.Add(driver);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Driver, DriverDto>(driver);
        }

        public async Task<bool> DeleteDriver(int driverId)
        {
            Driver driver = await _dbContext.Drivers.Where(x => x.DriverId == driverId).FirstOrDefaultAsync();
            if (driverId == null)
            {
                return false;
            }
            _dbContext.Remove(driver);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<DriverDto> GetDriverById(int driverId)
        {
            Driver driver = await _dbContext.Drivers.Where(x => x.DriverId == driverId).FirstOrDefaultAsync();
            return _mapper.Map<Driver, DriverDto>(driver);
        }

        public async Task<IList<DriverDto>> GetAllDriver()
        {
            IList<Driver> driverList = await _dbContext.Drivers.ToListAsync();
            return _mapper.Map<IList<DriverDto>>(driverList);
        }

    }
}
