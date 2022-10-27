using InventoryManagementService.Models.Dto;
using InventoryManagementService.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryManagementController : ControllerBase
    {
        private readonly ILogger<InventoryManagementController> _logger;
        private readonly IPalletRepository _palletRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILPNRepository _lpnRepository;
        private readonly INodeRepository _nodeRepository;
        // private readonly IRabbitMQSender _rabbitMQ;

        public InventoryManagementController(ILogger<InventoryManagementController> logger, IPalletRepository palletRepository, ILPNRepository lpnRepository, IProductRepository productRepository, INodeRepository nodeRepository)
        {
            _logger = logger;
            _palletRepository = palletRepository;
            _lpnRepository = lpnRepository;
            _productRepository = productRepository;
            _nodeRepository = nodeRepository;
        }

        [HttpGet("/pallet")]
        public async Task<ActionResult> GetAllPallets()
        {
            IList<PalletDto> palletResponse = await _palletRepository.GetAllPallets();
            if (palletResponse == null)
            {
                return NotFound();
            }
            return Ok(palletResponse);
        }

        [HttpGet("/product")]
        public async Task<ActionResult> GetAllProduct()
        {
            IList<ProductDto> productDtos = await _productRepository.GetAllProduct();
            if (productDtos == null)
            {
                return NotFound();
            }
            return Ok(productDtos);
        }

        [HttpGet("/product/location")]
        public async Task<ActionResult> GetNodeByProductId([FromQuery]int id)
        {
            _logger.LogInformation("start = {0}", id.ToString());
            IList<NodeDto> nodeDtos = await _nodeRepository.GetNodeByProductId(id);
            if (nodeDtos == null)
            {
                return NotFound();
            }
            return Ok(nodeDtos);
        }
    }
}
