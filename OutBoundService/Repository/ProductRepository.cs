using OutBoundService.Models.Dto;
using OutBoundService.Repository.Interface;
using Newtonsoft.Json;

namespace OutBoundService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient client;

        public ProductRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<ProductDto> UpdateProductPriority(int id, int priority)
        {
            var response = await client.PutAsync($"/product/{id}/{priority}",null);
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ProductDto>(apiContent);
            if (resp != null)
            {
                return resp;
            }
            return new ProductDto();
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var response = await client.GetAsync($"/api/product/{id}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ProductDto>(apiContent);
            if (resp != null)
            {
                return resp;
            }
            return new ProductDto();
        }

    }
}
