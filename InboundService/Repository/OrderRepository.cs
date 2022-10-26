using AutoMapper;
using InboundService.DbContexts;
using InboundService.Models;
using InboundService.Models.Dto;
using InboundService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InboundService.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly InboundDbContext _dbContext;
        private readonly IProductRepository _productRepository; 
        private IMapper _mapper;

        public OrderRepository(InboundDbContext dbContext,IProductRepository productRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _productRepository = productRepository; 
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateUpdateOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);

            if (order.OrderId > 0)
            {
                _dbContext.Orders.Update(order);
            }
            else
            {
                _dbContext.Orders.Add(order);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            Order order = await _dbContext.Orders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
            if (order == null)
            {
                return false;
            }
            _dbContext.Remove(order);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<OrderDto> GetOrderById(int orderId)
        {
            Order order = await _dbContext.Orders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            IEnumerable<Order> orderList = await _dbContext.Orders.ToListAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orderList);
        }

        public async Task<OrderDto> StatusUpdateOrder(int orderId, string status)
        {
            Order order = await _dbContext.Orders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
            
            if(order == null)
            {
                return null;
            }
            else
            {
                order.Status = status;
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Order,OrderDto>(order);
        }
    }
}