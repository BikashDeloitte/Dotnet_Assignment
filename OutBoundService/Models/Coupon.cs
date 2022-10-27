using System.ComponentModel.DataAnnotations;

namespace OutBoundService.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
