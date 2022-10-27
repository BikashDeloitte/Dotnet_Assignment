using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutBoundService.Models.Dto;
using OutBoundService.Repository.Interface;

namespace OutBoundService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutboundController : ControllerBase
    {
        private readonly ILogger<OutboundController> _logger;
        private readonly ICustomerOrderRepository _customerOrderRespository;
        private readonly ICouponRepository _couponRepository;
        private readonly IProductRepository _productRespository;

        public OutboundController(ILogger<OutboundController> logger, ICustomerOrderRepository customerOrderRespository, IProductRepository productRespository, ICouponRepository couponRepository)
        {
            _logger = logger;
            _customerOrderRespository = customerOrderRespository;
            _productRespository = productRespository;
            _couponRepository = couponRepository;
        }

        //create order from customer
        [HttpPost("/customerOrder")]
        public async Task<ActionResult<string>> CreateCustomerOrder([FromBody] CustomerOrderDto customerOrderDto)
        {
            try
            {
                await _customerOrderRespository.CreateUpdateCustomerOrder(customerOrderDto);
                _logger.LogInformation("created the Customer Order");
                return StatusCode(StatusCodes.Status201Created, "Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue Customer Order object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Override product priority
        [HttpPut("/product/{id}/{priority}")]
        public async Task<ActionResult<ProductDto>> UpdateProductPriority(int id, int priority)
        {
            try
            {
                ProductDto productDto = await _productRespository.UpdateProductPriority(id, priority);
                _logger.LogInformation("priority update");
                return StatusCode(StatusCodes.Status201Created, productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue with id or priority should be 1 to 10");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //create coupon 
        [HttpPost("coupon")]
        public async Task<ActionResult<string>> CreateOrder([FromBody] CouponDto couponDto)
        {
            try
            {
                await _couponRepository.CreateUpdateCoupon(couponDto);
                _logger.LogInformation("created the order");
                return StatusCode(StatusCodes.Status201Created, "Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue order object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //get all coupon
        [HttpGet("/coupon")]
        public async Task<ActionResult<IList<CouponDto>>> GetAllCoupons()
        {
            try
            {
                IList<CouponDto> couponDtos = await _couponRepository.GetAllCoupon();

                if (!couponDtos.Any())
                {
                    _logger.LogError("There is no coupon in database");
                    return NotFound();
                }
                _logger.LogInformation("found all coupons");
                return Ok(couponDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue coupon object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //get coupons by coupon Id
        [HttpGet("/coupon/{id:int}")]
        public async Task<ActionResult<CouponDto>> GetCouponById(int id)
        {
            try
            {
                CouponDto couponDto = await _couponRepository.GetCouponById(id);

                if (couponDto == null)
                {
                    _logger.LogError("coupon not found");
                    return NotFound();
                }
                _logger.LogInformation("found the coupon");
                return Ok(couponDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue coupon object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
