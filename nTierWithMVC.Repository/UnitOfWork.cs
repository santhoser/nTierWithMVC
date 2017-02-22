using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nTierWithMVC.DAL;

namespace nTierWithMVC.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private nTierWithMVCContext _context;

        public UnitOfWork(nTierWithMVCContext context)
        {
            this._context = context;
            this._context.Configuration.LazyLoadingEnabled = false;
        }
        public nTierWithMVCContext DbContext
        {
            get
            {
                return _context;
            }
        }

        public int Save()
        {
           return  _context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this._context != null)
                    {
                        this._context.Dispose();
                        this._context = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        #endregion

    }
}
