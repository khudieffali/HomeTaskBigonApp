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
    internal class CategoryGetAllHandlerRequest(ICategoryRepository categoryRepository) : IRequestHandler<CategoryGetAllRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<IEnumerable<Category>> Handle(CategoryGetAllRequest request, CancellationToken cancellationToken)
        {
            var response = await _categoryRepository.GetAll(x => x.DeletedBy == null);
            return [..response];
        }
    }
}
