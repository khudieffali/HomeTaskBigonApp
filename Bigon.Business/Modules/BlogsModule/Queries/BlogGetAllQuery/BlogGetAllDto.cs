using Bigon.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Queries.BlogGetAllQuery
{
    public class BlogGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
   
    }
}
