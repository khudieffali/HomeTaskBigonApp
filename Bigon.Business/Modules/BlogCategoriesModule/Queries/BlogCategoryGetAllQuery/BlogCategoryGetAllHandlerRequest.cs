using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogCategoriesModule.Queries.BlogCategoryGetAllQuery
{
    internal class BlogCategoryGetAllHandlerRequest(IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogCategoryGetAllRequest, IEnumerable<BlogCategory>>
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;

        public async Task<IEnumerable<BlogCategory>> Handle(BlogCategoryGetAllRequest request, CancellationToken cancellationToken)
        {
            return await _blogCategoryRepository.GetAll(x => x.DeletedBy == null);
        }
    }
}
