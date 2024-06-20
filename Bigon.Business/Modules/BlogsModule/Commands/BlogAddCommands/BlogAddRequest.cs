using Bigon.Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Commands.BlogAddCommands
{
    public class BlogAddRequest:IRequest<Blog>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ImagePath { get; set; }

    }
}
