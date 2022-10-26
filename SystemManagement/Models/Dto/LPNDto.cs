using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Models.Dto
{
    public class LPNDto
    {
        public long LPNId { get; set; }
        public NodeDto Node { get; set; }
    }
}
