using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Extension;
using Bigon.Infrastructure.Repositories;
using Bigon.Infrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Commands.BlogEditCommands
{
    internal class BlogEditHandlerRequest(IBlogRepository blogRepository,
        IFileService fileService) : IRequestHandler<BlogEditRequest, Blog>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IFileService _fileService = fileService;

        public async Task<Blog> Handle(BlogEditRequest request, CancellationToken cancellationToken)
        {
           var editBlog= await _blogRepository.GetById(x=>x.Id==request.Id && x.DeletedBy==null);
            editBlog.BlogCategoryId = request.BlogCategoryId;
            editBlog.Slug = request.Name.ToSlug();
            editBlog.Name = request.Name;
            editBlog.Description = request.Description;
            editBlog.ImagePath= await _fileService.ChangeFileAsync(request.ImagePath, editBlog.ImagePath,true);
            await _blogRepository.Save();
            return editBlog;
        }
    }
}
