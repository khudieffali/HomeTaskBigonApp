using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Queries.BlogGetByIdQuery
{
    public class BlogGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int PublishedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
