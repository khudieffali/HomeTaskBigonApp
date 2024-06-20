using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.CategoriesModule.Commands.CategoryAddCommands
{
    internal class CategoryAddHandlerRequest(ICategoryRepository categoryRepository) : IRequestHandler<CategoryAddRequest, Category>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<Category> Handle(CategoryAddRequest request, CancellationToken cancellationToken)
        {
            var newCategory= new Category
            {
                Name= request.Name,
                Description= request.Description,
                ParentId= request.ParentId,
            };
            await _categoryRepository.Add(newCategory);
            return newCategory;
        }
    }
}
