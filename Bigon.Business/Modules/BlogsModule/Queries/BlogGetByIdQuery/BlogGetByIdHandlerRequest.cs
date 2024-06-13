using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Queries.BlogGetByIdQuery
{
    internal class BlogGetByIdHandlerRequest(IBlogRepository blogRepository,IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogGetByIdRequest, BlogGetByIdDto>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;

        public async Task<BlogGetByIdDto> Handle(BlogGetByIdRequest request, CancellationToken cancellationToken)
        {
            var blog = (from bl in await _blogRepository.GetAll(x => x.DeletedBy == null)
                        join ct in await _blogCategoryRepository.GetAll() on bl.BlogCategoryId equals ct.Id
                        where bl.Id==request.Id
                        select new BlogGetByIdDto
                        {
                            Id = bl.Id,
                            Name = bl.Name,
                            Description = bl.Description,
                            ImagePath= bl.ImagePath,
                            Slug = bl.Slug,
                            BlogCategoryId = bl.BlogCategoryId,
                            BlogCategoryName=ct.Name,
                            PublishedAt= bl.PublishedAt,
                            PublishedBy= bl.PublishedBy,
                            CreatedAt= bl.CreatedAt,
                            CreatedBy= bl.CreatedBy,
                            ModifiedAt= bl.ModifiedAt,
                            ModifiedBy = bl.ModifiedBy,
                        }
                        );
            var data = blog.FirstOrDefault();
            return data;
        }
    }
}
