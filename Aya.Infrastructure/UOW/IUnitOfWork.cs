using Aya.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aya.Infrastructure.UOW
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
    }
}
