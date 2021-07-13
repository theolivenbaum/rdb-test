using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using RocksDbSharp;

namespace rdb_test
{
    public abstract class RocksDbBase : IDisposable
    {
        protected volatile bool _closed = false;

        internal volatile RocksDb DB;
        internal DbOptions DBOptions;

        private static readonly object _lockDB = new object();
        public long MemoryUsageInBytes { get; private set; }

        ~RocksDbBase() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _closed = true;

            if (disposing)
            {
                if (DB is object)
                {
                    lock (_lockDB)
                    {
                        if (DB is RocksDb db)
                        {
                            DB = null;
                            db.Dispose();
                        }
                    }
                }
            }
        }
    }
}
