using SystemManagement.Models.Dto;

namespace SystemManagement.Repository.Interface
{
    public interface IPalletRepository
    {
        Task<IList<PalletDto>> GetAllPallets();
        Task<PalletDto> GetPalletById(int palletId);
        Task<PalletDto> CreateUpdatePallet(PalletDto palletDto);
        Task<bool> DeletePallet(int palletId);
        Task<IList<PalletDto>> GetProductQuantity(int id);
    }
}
