using System;

namespace VfpClient.Benchmarks
{
    public class SecKey
    {
        public string secid { get; set; } = default!;
        public string seckey { get; set; } = default!;
        public string sectype { get; set; } = default!;
        public bool seccan { get; set; } = default!;
        public int seclevel { get; set; } = default!;
        public string userid { get; set; } = default!;
        public DateTime? cdate { get; set; }
        public string guid { get; set; } = default!;
    }
}
