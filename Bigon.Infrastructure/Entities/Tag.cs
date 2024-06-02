using Bigon.Infrastructure.Commons.Concretes;

namespace Bigon.Infrastructure.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
