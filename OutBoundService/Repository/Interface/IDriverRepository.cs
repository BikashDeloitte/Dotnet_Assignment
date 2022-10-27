using OutBoundService.Models.Dto;

namespace OutBoundService.Repository.Interface
{
    public interface IDriverRepository
    {
        Task<IList<DriverDto>> GetAllDriver();
        Task<DriverDto> GetDriverById(int driverId);
        Task<bool> DeleteDriver(int driverId);
        Task<DriverDto> CreateUpdateDriver(DriverDto driverDto);
    }
}
