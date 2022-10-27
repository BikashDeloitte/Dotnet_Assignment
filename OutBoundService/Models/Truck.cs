using System.ComponentModel.DataAnnotations;

namespace OutBoundService.Models
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        public string RegistrationNumber { get; set; }

        public string Model { get; set; }
    }
}
