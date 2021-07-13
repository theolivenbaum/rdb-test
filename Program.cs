using System;
using System.IO;

namespace rdb_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = Path.Combine(Path.GetTempPath(), "rdb_test");
            Directory.Delete(basePath, true);
            Directory.CreateDirectory(basePath);

            var rocksDbPath = Path.Combine(basePath, "storage", nameof(RocksDbStorage));
            var rocksDbJournalPath = Path.Combine(basePath, "journal", nameof(RocksDbStorage));

            while (true)
            {
                Console.Write(".");

                using var DB      = new RocksDbStorage(rocksDbPath, rocksDbJournalPath);
            }
        }
    }
}
