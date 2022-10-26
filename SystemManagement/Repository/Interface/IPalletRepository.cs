using SystemManagement.Models.Dto;

namespace SystemManagement.Repository.Interface
{
    public interface IPalletRepository
    {
        Task<IEnumerable<PalletDto>> GetAllPallets();
        Task<PalletDto> GetPalletById(int palletId);
        Task<PalletDto> CreateUpdatePallet(PalletDto palletDto);
        Task<bool> DeletePallet(int palletId);
        Task<PalletDto> GetProductQuantity(int id);
    }
}
