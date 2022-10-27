using OutBoundService.Models.Dto;

namespace OutBoundService.Repository.Interface
{
    public interface ITruckRepository
    {
        Task<IList<TruckDto>> GetAllTruck();
        Task<TruckDto> GetTruckById(int truckId);
        Task<bool> DeleteTruck(int truckId);
        Task<TruckDto> CreateUpdateTruck(TruckDto truckDto);
    }
}
