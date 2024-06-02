using Bigon.Infrastructure.Commons.Concretes;

namespace Bigon.Infrastructure.Entities
{
    public class BlogCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
