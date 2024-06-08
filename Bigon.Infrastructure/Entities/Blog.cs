using Bigon.Infrastructure.Commons.Concretes;

namespace Bigon.Infrastructure.Entities
{
    public class Blog : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public string  Slug { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory? BlogCategory { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int PublishedBy { get; set; }

    }
}
