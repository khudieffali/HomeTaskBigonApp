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
    internal class BlogGetByIdHandlerRequest(IBlogRepository blogRepository,ICategoryRepository categoryRepository) : IRequestHandler<BlogGetByIdRequest, BlogGetByIdDto>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<BlogGetByIdDto> Handle(BlogGetByIdRequest request, CancellationToken cancellationToken)
        {
            var blog = (from bl in await _blogRepository.GetAll(x => x.DeletedBy == null)
                        join ct in await _categoryRepository.GetAll() on bl.CategoryId equals ct.Id
                        where bl.Id==request.Id
                        select new BlogGetByIdDto
                        {
                            Id = bl.Id,
                            Name = bl.Name,
                            Description = bl.Description,
                            ImagePath= bl.ImagePath,
                            Slug = bl.Slug,
                            CategoryId = bl.CategoryId,
                            CategoryName=ct.Name,
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
