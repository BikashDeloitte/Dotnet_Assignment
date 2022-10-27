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
        private readonly ICustomerOrderRespository _customerOrderRespository;
        private readonly IProductRepository _productRespository;

        public OutboundController(ILogger<OutboundController> logger, ICustomerOrderRespository customerOrderRespository, IProductRepository productRespository)
        {
            _logger = logger;
            _customerOrderRespository = customerOrderRespository;
            _productRespository = productRespository;
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
    }
}
