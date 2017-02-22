using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nTierWithMVC.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        DAL.nTierWithMVCContext DbContext { get; }
        int Save();
    }
}
