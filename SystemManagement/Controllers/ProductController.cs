using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Interface;

namespace SystemManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IPalletRepository _palletRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository, IPalletRepository palletRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _palletRepository = palletRepository;
        }

        //get all products
        [HttpGet("/product")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetAllProducts();

                if (!productDtos.Any())
                {
                    _logger.LogError("There is no products in database");
                    return NotFound();
                }
                _logger.LogInformation("found all products");
                return Ok(productDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue product object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //get product by product Id
        [HttpGet("/product/{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);

                if (productDto == null)
                {
                    _logger.LogError("product not found");
                    return NotFound();
                }
                _logger.LogInformation("found the product");
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue product object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //create product
        [HttpPost("/product")]
        public async Task<ActionResult<string>> CreateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                await _productRepository.CreateUpdateProduct(productDto);
                _logger.LogInformation("created the product");
                return StatusCode(StatusCodes.Status201Created, "Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue product object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //update product
        [HttpPut("/product")]
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto product = await _productRepository.CreateUpdateProduct(productDto);
                _logger.LogInformation("product updated");
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue product object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //delete product by product id
        [HttpDelete("/product/{id:int}")]
        public async Task<ActionResult<string>> DeleteProduct(int id)
        {
            try
            {
                if (await _productRepository.DeleteProduct(id))
                {
                    _logger.LogInformation("product deleted");
                    return Ok("Successfully Deleted");
                }
                else
                {
                    _logger.LogError("product not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue product object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //check present is present or not
        [HttpGet("/product/check")]
        public ActionResult<bool> CheckProductById([FromQuery]int id)
        {
            return _productRepository.CheckProductById(id);
        }


        //create pallet
        [HttpPost("/pallet")]
        public async Task<ActionResult<string>> CreatePallet([FromBody] PalletDto palletDto)
        {
            try
            {
                await _palletRepository.CreateUpdatePallet(palletDto);
                _logger.LogInformation("created the pallet");
                return StatusCode(StatusCodes.Status201Created, "Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue product object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
