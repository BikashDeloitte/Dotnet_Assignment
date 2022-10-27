using InventoryManagementService.Models.Dto;

namespace InventoryManagementService.Repository.Interface
{
    public interface INodeRepository
    {
        Task<IList<NodeDto>> GetNodeByProductId(int id);
    }
}
