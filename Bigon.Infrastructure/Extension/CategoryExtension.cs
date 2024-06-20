using Bigon.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Infrastructure.Extension
{
    public static class CategoryExtension
    {
        public static IEnumerable<Category> GetHeirArchy(this IEnumerable<Category> categories, Category parent)
        {
            if(parent.ParentId != null)
            {
                yield return parent;
            }
            foreach (var item in categories.Where(x=>x.ParentId==parent.Id &&x.DeletedBy==null).SelectMany(c=>categories.GetHeirArchy(c)))
            {
                yield return item; 
            }
        }
    }
}
