using SystemManagement.Models.Dto;

namespace SystemManagement.Repository.Interface
{
    public interface INodeRepository
    {
        Task<IEnumerable<NodeDto>> GetAllNodes();
        Task<NodeDto> GetNodeById(int nodeId);
        Task<NodeDto> CreateUpdateNode(NodeDto nodeDto);
        Task<bool> DeleteNode(int nodeId);
    }
}
