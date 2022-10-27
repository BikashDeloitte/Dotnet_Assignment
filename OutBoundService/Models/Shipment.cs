using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutBoundService.Models
{
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public string ShipmentStatus { get; set; }
        public string ShipmentTime { get; set; }
        [ForeignKey("Truck")]
        public int TruckId { get; set; }
        public Truck Truck { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }  
    }
}
