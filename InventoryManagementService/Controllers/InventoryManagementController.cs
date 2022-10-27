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

        //View Pallets Details
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

        //View Product Details
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

        //View Product location
        [HttpGet("/product/location")]
        public async Task<ActionResult> GetNodeByProductId([FromQuery]int id)
        {
            IList<NodeDto> nodeDtos = await _nodeRepository.GetNodeByProductId(id);
            if (nodeDtos == null)
            {
                return NotFound();
            }
            return Ok(nodeDtos);
        }

        //Update Product Information
        [HttpPut("/product/update")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            var productResponse = await _productRepository.UpdateProduct(productDto);
            if (!productResponse.IsSuccessStatusCode)
            {
                return Ok(productResponse);
            }
            return Ok("successfully");
        }

        //Update/Manage LPN
        [HttpPut("/lpn/update")]
        public async Task<ActionResult> Updatelpn([FromBody] LPNDto lpnDto)
        {
            var lpnResponse = await _lpnRepository.UpdateLPN(lpnDto);
            if (!lpnResponse.IsSuccessStatusCode)
            {
                return Ok(lpnResponse);
            }
            return Ok("successfully");
        }

        //Search APIs for the Products.
        [HttpGet("/product/search")]
        public async Task<ActionResult> SearchProductByName([FromQuery] string name)
        {
            IList<ProductDto> productDtos = await _productRepository.SearchProductByName(name);
            if (productDtos == null)
            {
                return NotFound();
            }
            return Ok(productDtos);
        }
    }
}
