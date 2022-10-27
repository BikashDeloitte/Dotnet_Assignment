using InventoryManagementService.Models.Dto;

namespace InventoryManagementService.Repository.Interface
{
    public interface IPalletRepository
    {
        Task<IList<PalletDto>> GetAllPallets();
    }
}
