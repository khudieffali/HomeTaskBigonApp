using Bigon.Business.Modules.BlogsModule.Queries.BlogGetAllQuery;
using Bigon.Data.Repositories;
using Bigon.Infrastructure.Repositories;
using Bigon.Infrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Commands.BlogRemoveCommands
{
    internal class BlogRemoveHandlerRequest(IBlogRepository blogRepository,
        IFileService fileService,
        ICategoryRepository categoryRepository) : IRequestHandler<BlogRemoveRequest, IEnumerable<BlogGetAllDto>>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IFileService _fileService = fileService;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<IEnumerable<BlogGetAllDto>> Handle(BlogRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity=await _blogRepository.GetById(x=>x.Id==request.Id && x.DeletedBy==null);
            entity.ImagePath =await _fileService.ChangeFileAsync(null, entity.ImagePath);
            await _blogRepository.Remove(entity);

            var data = (from bl in await _blogRepository.GetAll(x => x.DeletedBy == null)
                        join ct in await _categoryRepository.GetAll() on bl.CategoryId equals ct.Id
                        select new BlogGetAllDto
                        {
                            Id = bl.Id,
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
