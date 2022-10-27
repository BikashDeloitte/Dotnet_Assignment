using SystemManagement.Models.Dto;

namespace SystemManagement.Repository.Interface
{
    public interface ILPNRepository
    {
        Task<IEnumerable<LPNDto>> GetAllLPNs();
        Task<LPNDto> GetLPNById(int lpnd);
        Task<LPNDto> CreateUpdateLPN(LPNDto lpnDto);
        Task<bool> DeleteLPN(int lpnId);
        Task<IList<NodeDto>> GetProductLocationById(int productId);
    }
}
