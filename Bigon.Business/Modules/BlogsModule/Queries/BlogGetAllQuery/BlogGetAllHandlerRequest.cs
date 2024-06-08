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
    internal class BlogGetAllHandlerRequest(IBlogRepository blogRepository,IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogGetAllRequest, IEnumerable<BlogGetAllDto>>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;

        public async Task<IEnumerable<BlogGetAllDto>> Handle(BlogGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = (from bl in await _blogRepository.GetAll(x => x.DeletedBy == null)
                               join ct in await _blogCategoryRepository.GetAll() on bl.BlogCategoryId equals ct.Id
                               select new BlogGetAllDto
                               {
                                   Id= bl.Id,
                                   Name = bl.Name,
                                   Description = bl.Description,
                                   BlogCategoryId = bl.BlogCategoryId,
                                   BlogCategoryName = ct.Name,
                                   ImagePath = bl.ImagePath,
                                   Slug = bl.Slug,
                               }).ToList();
            return data;
        }
    }
}
