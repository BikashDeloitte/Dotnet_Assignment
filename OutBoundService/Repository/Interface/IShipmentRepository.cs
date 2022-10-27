using OutBoundService.Models.Dto;

namespace OutBoundService.Repository.Interface
{
    public interface IShipmentRepository
    {
        Task<IList<ShipmentDto>> GetAllShipment();
        Task<ShipmentDto> GetShipmentById(int shipmentId);
        Task<bool> DeleteShipment(int shipmentId);
        Task<ShipmentDto> CreateUpdateShipment(ShipmentDto shipmentDto);
        Task<ShipmentDto> ShipmentStatus(int id, string status);
    }
}
