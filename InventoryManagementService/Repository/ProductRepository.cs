using InventoryManagementService.Models.Dto;
using InventoryManagementService.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace InventoryManagementService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient client;

        public ProductRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<IList<ProductDto>> GetAllProduct()
        {
            var response = await client.GetAsync($"/product");
            var resp = JsonConvert.DeserializeObject<ProductDto[]>(response.Content.ReadAsStringAsync().Result);

            return resp;
        }

        public async Task<IList<ProductDto>> SearchProductByName(string name)
        {
            var response = await client.GetAsync($"/product");
            var resp = JsonConvert.DeserializeObject<ProductDto[]>(response.Content.ReadAsStringAsync().Result);
            return resp.Where(x => x.Name == name).ToList();

        }

        public async Task<HttpResponseMessage> UpdateProduct(ProductDto productDto)
        {
            var myContent = JsonConvert.SerializeObject(productDto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync($"/product", byteContent);
            return response;
        }
    }
}
