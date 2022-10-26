using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SystemManagement.DbContexts;
using SystemManagement.Models;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Interface;

namespace SystemManagement.Repository
{
    public class LPNRepository : ILPNRepository
    {
        private readonly SystemManagementDbContext _dbContext;
        private IMapper _mapper;

        public LPNRepository(SystemManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<LPNDto> CreateUpdateLPN(LPNDto lpnDto)
        {
            LPN lpn = _mapper.Map<LPNDto, LPN>(lpnDto);
            if (lpn.LPNId > 0)
            {
                _dbContext.LPNs.Update(lpn);
            }
            else
            {
                _dbContext.LPNs.Add(lpn);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<LPN,LPNDto>(lpn);
        }

        public async Task<bool> DeleteLPN(int lpnId)
        {
            LPN lpn = await _dbContext.LPNs.Where(x => x.LPNId == lpnId).FirstOrDefaultAsync();
            if (lpn == null)
            {
                return false;
            }
            _dbContext.Remove(lpn);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LPNDto>> GetAllLPNs()
        {
            IEnumerable<LPN> lpnList = await _dbContext.LPNs.ToListAsync();
            return _mapper.Map<IEnumerable<LPNDto>>(lpnList);
        }

        public async Task<LPNDto> GetLPNById(int lpnId)
        {
            LPN lpn = await _dbContext.LPNs.Where(x => x.LPNId == lpnId).FirstOrDefaultAsync();
            return _mapper.Map<LPN, LPNDto>(lpn);
        }
    }
}
