using Azure.Core;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Extension;
using Bigon.Infrastructure.Repositories;
using Bigon.Infrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogsModule.Commands.BlogAddCommands
{
    internal class BlogAddHandlerRequest(IBlogRepository blogRepository,
        IFileService fileService) : IRequestHandler<BlogAddRequest, Blog>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IFileService _fileService = fileService;

        public async Task<Blog> Handle(BlogAddRequest request, CancellationToken cancellationToken)
        {
            var fileName = await _fileService.UploadFileAsync(request.ImagePath);
            var newBlog = new Blog
            {
                Name = request.Name,
                Description = request.Description,
                ImagePath = fileName,
                Slug = request.Name.ToSlug(),
                BlogCategoryId = request.BlogCategoryId
            };
            await _blogRepository.Add(newBlog);
            return newBlog;
        }
    }
}
