using InboundService.Models;
using InboundService.Models.Dto;

using InboundService.Repository.Interface;

using Microsoft.AspNetCore.Mvc;

namespace InboundService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IPalletRepository _palletRepository;
        private readonly ILPNRepository _lpnRepository; 
        // private readonly IRabbitMQSender _rabbitMQ;

        public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository, IPalletRepository palletRepository, ILPNRepository lpnRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _palletRepository = palletRepository;
            _lpnRepository = lpnRepository;
            // _rabbitMQ = rabbitMQ;
        }

        /*
        [HttpPost("/order/RabbitMQ")]
        public string GetRabbitMQ(Order order)
        {
            _rabbitMQ.SendMessage(order, "order");
            _logger.LogInformation("Order is sended");
            return "done";
        }*/

        [HttpGet("/order")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            try
            {
                IEnumerable<OrderDto> orderDtos = await _orderRepository.GetAllOrders();

                if (!orderDtos.Any())
                {
                    _logger.LogError("There is no orders in database");
                    return NotFound();
                }
                _logger.LogInformation("found all orders");
                return Ok(orderDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue order object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("/order/{id:int}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            try
            {
                OrderDto orderDto = await _orderRepository.GetOrderById(id);

                if (orderDto == null)
                {
                    _logger.LogError("order not found");
                    return NotFound();
                }
                _logger.LogInformation("found the order");
                return Ok(orderDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue order object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/order")]
        public async Task<ActionResult<string>> CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                await _orderRepository.CreateUpdateOrder(orderDto);
                _logger.LogInformation("created the order");
                return StatusCode(StatusCodes.Status201Created, "Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue order object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("/order")]
        public async Task<ActionResult<OrderDto>> UpdateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                OrderDto order = await _orderRepository.CreateUpdateOrder(orderDto);
                _logger.LogInformation("order updated");
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue order object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("/order/{id:int}")]
        public async Task<ActionResult<string>> DeleteOrder(int id)
        {
            try
            {
                if (await _orderRepository.DeleteOrder(id))
                {
                    _logger.LogInformation("order deleted");
                    return Ok("Successfully Deleted");
                }
                else
                {
                    _logger.LogError("order not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue order object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("/order/statusUpdate")]
        public async Task<ActionResult<OrderDto>> StatusUpdateOrder([FromQuery] int orderId, [FromQuery] string status)
        {
            try
            {
                OrderDto order = await _orderRepository.StatusUpdateOrder(orderId, status);

                if (order == null)
                {
                    _logger.LogError("order not found");
                    return NotFound();
                }

                _logger.LogInformation("order status updated");
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue order object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/pallet")]
        public async Task<ActionResult> UpdatePallet([FromBody] PalletDto palletDto)
        {
            var palletResponse = await _palletRepository.UpdatePallet(palletDto);
            if (!palletResponse.IsSuccessStatusCode)
            {
                return Ok(palletResponse);
            }
            return Ok("Successfully");
        }

        [HttpPost("/lpn")]
        public async Task<ActionResult> UpdateLPN([FromBody] LPNDto lpnDto)
        {
            var lpnResponse = await _lpnRepository.UpdateLPN(lpnDto);
            if (!lpnResponse.IsSuccessStatusCode)
            {
                return Ok(lpnResponse);
            }
            return Ok("successfully");
        }

        [HttpGet("/product/quantity")]
        public async Task<ActionResult> GetPalletByProductId([FromQuery] int id)
        {
            var palletResponse = await _palletRepository.GetPalletByProductId(id);
            return Ok(palletResponse);
        }
    }
}