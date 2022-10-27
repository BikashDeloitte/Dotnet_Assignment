using System.ComponentModel.DataAnnotations.Schema;

namespace OutBoundService.Models.Dto
{
    public class ShipmentDto
    {
        public int ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public string ShipmentStatus { get; set; }
        public string ShipmentTime { get; set; }
        public int TruckId { get; set; }
        public TruckDto Truck { get; set; }
        public int DriverId { get; set; }
        public DriverDto Driver { get; set; }

    }
}
