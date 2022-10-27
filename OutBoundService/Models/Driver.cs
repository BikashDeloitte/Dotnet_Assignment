using System.ComponentModel.DataAnnotations;

namespace OutBoundService.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }
    }
}
