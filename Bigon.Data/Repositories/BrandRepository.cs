using Bigon.Infrastructure.Commons.Abstracts;
using Bigon.Infrastructure.Commons.Concretes;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Data.Repositories
{
    public class BrandRepository(DbContext db) : Repository<Brand>(db),IBrandRepository
    {
    
    }
}
