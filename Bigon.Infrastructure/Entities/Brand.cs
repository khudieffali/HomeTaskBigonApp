using Bigon.Infrastructure.Commons.Concretes;

namespace Bigon.Infrastructure.Entities
{
    public class Brand : BaseEntity<int>
    {
        public string BrandName { get; set; }
        public string? Description { get; set; }
    }
}
