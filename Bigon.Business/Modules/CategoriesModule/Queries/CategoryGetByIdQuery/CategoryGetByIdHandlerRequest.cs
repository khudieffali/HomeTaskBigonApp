using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    internal class CategoryGetByIdHandlerRequest(ICategoryRepository categoryRepository) : IRequestHandler<CategoryGetByIdRequest, CategoryGetByIdDto>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<CategoryGetByIdDto> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {
            var query= (from current in await _categoryRepository.GetAll(x=>x.Id==request.Id)
                        join parent in await _categoryRepository.GetAll() on current.ParentId equals parent.Id
                        into lj from leftJoin in lj.DefaultIfEmpty()
                        select new CategoryGetByIdDto
                        {
                            Name=current.Name,
                            ParentId=current.ParentId,
                            Description=current.Description,
                            ParentName=leftJoin.Name,
                            CreatedAt=current.CreatedAt,
                            CreatedBy=current.CreatedBy, 
                            ModifiedAt=current.ModifiedAt,
                            ModifiedBy=current.ModifiedBy,
                        });
            return await query.FirstOrDefaultAsync();
        }
    }
}
