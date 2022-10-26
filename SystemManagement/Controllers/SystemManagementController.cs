using Microsoft.AspNetCore.Mvc;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Interface;

namespace SystemManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemManagementController : ControllerBase
    {
        private IProductRepository _productRepository;
        private ILPNRepository _lpnRespoitory;
        private IPalletRepository _palletRepository;
        private readonly ILogger<SystemManagementController> _logger;

        public SystemManagementController(ILogger<SystemManagementController> logger, IProductRepository productRepository, IPalletRepository palletRepository, ILPNRepository lpnRespoitory)
        {
            _logger = logger;
            _productRepository = productRepository;
            _palletRepository = palletRepository;
            _lpnRespoitory = lpnRespoitory;
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
        public ActionResult<bool> CheckProductById([FromQuery] int id)
        {
            return _productRepository.CheckProductById(id);
        }


        //create pallet
        [HttpPost("/pallet")]
        public async Task<ActionResult<string>> CreateUpdatePallet([FromBody] PalletDto palletDto)
        {
            try
            {
                await _palletRepository.CreateUpdatePallet(palletDto);
                _logger.LogInformation("created the pallet");
                if (palletDto.PalletId > 0)
                {
                    Ok("Successfully updated");
                }
                return StatusCode(StatusCodes.Status201Created, "Successfully created");
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue product object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //create LPN
        [HttpPost("/lpn")]
        public async Task<ActionResult<string>> CreateUpdateLPN([FromBody] LPNDto lpnDto)
        {
            try
            {
                await _lpnRespoitory.CreateUpdateLPN(lpnDto);
                _logger.LogInformation("created the pallet");
                if (lpnDto.LPNId > 0)
                {
                    Ok("Successfully updated");
                }
                return StatusCode(StatusCodes.Status201Created, "Successfully created");
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue product object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("/product/quantity/{id}")]
        public async Task<ActionResult<PalletDto>> GetProductQuantity(int id)
        {
            try
            {
                PalletDto palletDtos = await _palletRepository.GetProductQuantity(id);
                _logger.LogInformation("found all pallests");
                return Ok(palletDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("There is some issue pallet object");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }     
}
