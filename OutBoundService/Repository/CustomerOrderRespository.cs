using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OutBoundService.DbContexts;
using OutBoundService.Models;
using OutBoundService.Models.Dto;
using OutBoundService.Repository.Interface;

namespace OutBoundService.Repository
{
    public class CustomerOrderRespository : ICustomerOrderRespository
    {
        private readonly OutBoundServiceDbContext _dbContext;
        private IMapper _mapper;

        public CustomerOrderRespository(OutBoundServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CustomerOrderDto> CreateUpdateCustomerOrder(CustomerOrderDto customerOrderDto)
        {
            CustomerOrder customerOrder = _mapper.Map<CustomerOrderDto, CustomerOrder>(customerOrderDto);

            if (customerOrder.CustomerOrderId > 0)
            {
                customerOrder.ModifiedTime = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                _dbContext.CustomerOrders.Update(customerOrder);
            }
            else
            {
                customerOrder.ModifiedTime = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                customerOrder.CreationTime = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                _dbContext.CustomerOrders.Add(customerOrder);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CustomerOrder, CustomerOrderDto>(customerOrder);
        }

        public async Task<bool> DeleteCustomerOrder(int customerOrderId)
        {
            CustomerOrder customerOrder = await _dbContext.CustomerOrders.Where(x => x.CustomerOrderId == customerOrderId).FirstOrDefaultAsync();
            if (customerOrderId == null)
            {
                return false;
            }
            _dbContext.Remove(customerOrder);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerOrderDto> GetCustomerOrderById(int customerOrderId)
        {
            CustomerOrder customerOrder = await _dbContext.CustomerOrders.Where(x => x.CustomerOrderId == customerOrderId).FirstOrDefaultAsync();
            return _mapper.Map<CustomerOrder, CustomerOrderDto>(customerOrder);
        }

        public async Task<IList<CustomerOrderDto>> GetAllOrders()
        {
            IList<CustomerOrder> customerOrderList = await _dbContext.CustomerOrders.ToListAsync();
            return _mapper.Map<IList<CustomerOrderDto>>(customerOrderList);
        }

        public async Task<CustomerOrderDto> StatusUpdateCustomerOrder(int customerOrderId, string status)
        {
            CustomerOrder customerOrder = await _dbContext.CustomerOrders.Where(x => x.CustomerOrderId == customerOrderId).FirstOrDefaultAsync();

            if (customerOrder == null)
            {
                return null;
            }
            else
            {
                customerOrder.Status = status;
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CustomerOrder, CustomerOrderDto>(customerOrder);
        }
    }
}