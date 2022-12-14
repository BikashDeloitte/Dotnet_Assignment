using InboundService.Models.Dto;

namespace InboundService.Repository.Interface
{
    public interface IPalletRepository
    {
        Task<HttpResponseMessage> UpdatePallet(PalletDto palletDto);
        Task<long> GetPalletByProductId(int id);
    }
}
