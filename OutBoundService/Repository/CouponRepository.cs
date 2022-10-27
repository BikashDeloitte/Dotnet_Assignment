using AutoMapper;
using OutBoundService.DbContexts;
using OutBoundService.Models.Dto;
using OutBoundService.Models;
using OutBoundService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace OutBoundService.Repository
{
    public class CouponRepository: ICouponRepository
    {
        private readonly OutBoundServiceDbContext _dbContext;
        private IMapper _mapper;

        public CouponRepository(OutBoundServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto)
        {
            Coupon coupon = _mapper.Map<CouponDto, Coupon>(couponDto);

            if (coupon.CouponId > 0)
            {
                _dbContext.Coupons.Update(coupon);
            }
            else
            {
                _dbContext.Coupons.Add(coupon);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Coupon, CouponDto>(coupon);
        }

        public async Task<bool> DeleteCoupon(int couponId)
        {
            Coupon coupon = await _dbContext.Coupons.Where(x => x.CouponId == couponId).FirstOrDefaultAsync();
            if (couponId == null)
            {
                return false;
            }
            _dbContext.Remove(coupon);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CouponDto> GetCouponById(int couponId)
        {
            Coupon coupon = await _dbContext.Coupons.Where(x => x.CouponId == couponId).FirstOrDefaultAsync();
            return _mapper.Map<Coupon, CouponDto>(coupon);
        }

        public async Task<IList<CouponDto>> GetAllCoupon()
        {
            IList<Coupon> couponList = await _dbContext.Coupons.ToListAsync();
            return _mapper.Map<IList<CouponDto>>(couponList);
        }

        public async Task<CouponDto> GetCouponByCouponCode(string couponCode)
        {
            Coupon coupon = await _dbContext.Coupons.Where(x => x.CouponCode == couponCode).FirstOrDefaultAsync();
            return _mapper.Map<Coupon, CouponDto>(coupon);
        }

    }
}
