using InventoryManagementService.Controllers;
using InventoryManagementService.Models.Dto;
using InventoryManagementService.Repository.Interface;
using Newtonsoft.Json;

namespace InventoryManagementService.Repository
{
    public class NodeRepository : INodeRepository
    {
        private readonly HttpClient client;
        private readonly ILogger<NodeRepository> _logger;

        public NodeRepository(HttpClient client, ILogger<NodeRepository> logger)
        {
            this.client = client;
            _logger = logger;
        }
        public async Task<IList<NodeDto>> GetNodeByProductId(int id)
        {
            var response = await client.GetAsync($"/product/location/{id}");
            _logger.LogInformation("{0}",id.ToString());
            var resp = JsonConvert.DeserializeObject<NodeDto[]>(response.Content.ReadAsStringAsync().Result);

            return resp;
        }
    }
}
