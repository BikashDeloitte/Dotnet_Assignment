using OutBoundService.Models.Dto;

namespace OutBoundService.Repository.Interface
{
    public interface ICouponRepository
    {
        Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto);
        Task<IList<CouponDto>> GetAllCoupon();
        Task<CouponDto> GetCouponById(int couponId);
        Task<bool> DeleteCoupon(int couponId);
        Task<CouponDto> GetCouponByCouponCode(string couponCode);
    }
}
