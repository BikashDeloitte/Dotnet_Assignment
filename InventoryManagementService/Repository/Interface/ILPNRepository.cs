using InventoryManagementService.Models.Dto;

namespace InventoryManagementService.Repository.Interface
{
    public interface ILPNRepository
    {
        Task<HttpResponseMessage> UpdateLPN(LPNDto lpnDto);
    }
}
