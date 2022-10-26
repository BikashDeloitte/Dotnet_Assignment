using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemManagement.DbContexts;
using SystemManagement.Models;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Interface;

namespace SystemManagement.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly SystemManagementDbContext _dbContext;
        private IMapper _mapper;

        public ProductRepository(SystemManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _dbContext.Products.Update(product);
            }
            else
            {
                _dbContext.Products.Add(product);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            Product product = await _dbContext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            if (product == null)
            {
                return false;
            }
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _dbContext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<Product,ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<Product> productList = await _dbContext.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(productList);
        }

        //check wheather product is present or not
        public ActionResult<bool> CheckProductById(int id)
        {
            if(_dbContext.Products.Where(x => id == x.ProductId) == null)
            {
                return true;
            }
            return false;
        }
    }
}
