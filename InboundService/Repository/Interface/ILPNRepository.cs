using InboundService.Models.Dto;

namespace InboundService.Repository.Interface
{
    public interface ILPNRepository
    {
        Task<HttpResponseMessage> UpdateLPN(LPNDto lpnDto);
    }
}
