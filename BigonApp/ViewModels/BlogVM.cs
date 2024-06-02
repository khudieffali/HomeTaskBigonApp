
using Bigon.Infrastructure.Entities;

namespace BigonApp.ViewModels
{
    public class BlogVM
    {
        public Blog? Blog { get; set; }
        public List<Tag>? TagList { get; set; }
    }
}
