using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SystemManagement.DbContexts;
using SystemManagement.Models;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Interface;

namespace SystemManagement.Repository
{
    public class NodeRepository : INodeRepository
    {
        private readonly SystemManagementDbContext _dbContext;
        private IMapper _mapper;

        public NodeRepository(SystemManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NodeDto> CreateUpdateNode(NodeDto nodeDto)
        {
            Node node = _mapper.Map<NodeDto, Node>(nodeDto);
            if (node.NodeId > 0)
            {
                _dbContext.Nodes.Update(node);
            }
            else
            {
                _dbContext.Nodes.Add(node);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Node, NodeDto>(node);
        }

        public async Task<bool> DeleteNode(int nodeId)
        {
            Node node = await _dbContext.Nodes.Where(x => x.NodeId == nodeId).FirstOrDefaultAsync();
            if (node == null)
            {
                return false;
            }
            _dbContext.Remove(node);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<NodeDto> GetNodeById(int nodeId)
        {
            Node node = await _dbContext.Nodes.Include(c=> c.Warehouse).Where(x => x.NodeId == nodeId).FirstOrDefaultAsync();
            return _mapper.Map<Node, NodeDto>(node);
        }

        public async Task<IEnumerable<NodeDto>> GetAllNodes()
        {
            IEnumerable<Node> nodeList = await _dbContext.Nodes.Include(c => c.Warehouse).ToListAsync();
            return _mapper.Map<IEnumerable<NodeDto>>(nodeList);
        }
    }
}