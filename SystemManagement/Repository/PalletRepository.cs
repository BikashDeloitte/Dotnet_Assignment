using AutoMapper;
using SystemManagement.DbContexts;
using SystemManagement.Models.Dto;
using SystemManagement.Models;
using SystemManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace SystemManagement.Repository
{
    public class PalletRepository: IPalletRepository
    {
        private readonly SystemManagementDbContext _dbContext;
        private IMapper _mapper;

        public PalletRepository(SystemManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PalletDto> CreateUpdatePallet(PalletDto palletDto)
        {
            Pallet pallet = _mapper.Map<PalletDto, Pallet>(palletDto);
            if (pallet.PalletId > 0)
            {
                _dbContext.Pallets.Update(pallet);
            }
            else
            {
                _dbContext.Pallets.Add(pallet);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Pallet, PalletDto>(pallet);
        }

        public async Task<bool> DeletePallet(int palletId)
        {
            Pallet pallet = await _dbContext.Pallets.Where(x => x.PalletId == palletId).FirstOrDefaultAsync();
            if (pallet == null)
            {
                return false;
            }
            _dbContext.Remove(pallet);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PalletDto> GetPalletById(int palletId)
        {
            Pallet pallet = await _dbContext.Pallets.Where(x => x.PalletId == palletId).FirstOrDefaultAsync();
            return _mapper.Map<Pallet, PalletDto>(pallet);
        }

        public async Task<IEnumerable<PalletDto>> GetAllPallets()
        {
            IEnumerable<Pallet> palletList = await _dbContext.Pallets.ToListAsync();
            return _mapper.Map<IEnumerable<PalletDto>>(palletList);
        }
    }
}