using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Queries.BlogGetAllQuery
{
    internal class BlogGetAllHandlerRequest(IBlogRepository blogRepository,ICategoryRepository categoryRepository) : IRequestHandler<BlogGetAllRequest, IEnumerable<BlogGetAllDto>>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<IEnumerable<BlogGetAllDto>> Handle(BlogGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = (from bl in await _blogRepository.GetAll(x => x.DeletedBy == null)
                               join ct in await _categoryRepository.GetAll() on bl.CategoryId equals ct.Id
                               select new BlogGetAllDto
                               {
                                   Id= bl.Id,
                                   Name = bl.Name,
                                   Description = bl.Description,
                                   CategoryId = bl.CategoryId,
                                  CategoryName = ct.Name,
                                   ImagePath = bl.ImagePath,
                               }).ToList();
            return data;
        }
    }
}
