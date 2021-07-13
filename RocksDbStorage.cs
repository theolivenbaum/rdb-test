using System.IO;
using RocksDbSharp;

namespace rdb_test
{
    public sealed class RocksDbStorage : RocksDbBase
    {
        public RocksDbStorage(string path, string journalPath)
        {
            if (!Directory.Exists(path))        { Directory.CreateDirectory(path); }
            if (!Directory.Exists(journalPath)) { Directory.CreateDirectory(journalPath); }

            DBOptions = new DbOptions().SetCreateIfMissing(true)
                                       .SetCreateMissingColumnFamilies(true)
                                       .SetWalDir(journalPath);
            DB = RocksDb.Open(DBOptions, path);
        }
    }
}
