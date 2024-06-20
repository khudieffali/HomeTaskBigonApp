using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.CategoriesModule.Commands.CategoryRemoveCommands
{
    internal class CategoryRemoveHandlerRequest(ICategoryRepository categoryRepository) : IRequestHandler<CategoryRemoveRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<IEnumerable<Category>> Handle(CategoryRemoveRequest request, CancellationToken cancellationToken)
        {
            var removeCategory = await _categoryRepository.GetById(x => x.Id == request.Id && x.DeletedBy == null);
            await _categoryRepository.Remove(removeCategory);
            var categories = await _categoryRepository.GetAll(x => x.DeletedBy == null);
            return [.. categories];
        }
    }
}
