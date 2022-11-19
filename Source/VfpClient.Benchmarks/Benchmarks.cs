using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using VfpClient;
using Dapper;
using System.Collections.Generic;

namespace VfpClient.Benchmarks
{
    public class Benchmarks
    {
        [Benchmark]
        [BenchmarkCategory("Unbuffered")]
        public void Scenario1()
        {
            using var conn = new VfpConnection();
            conn.ConnectionString = "Provider=VFPOLEDB.1;Data Source=.\\Data";
            conn.Open();
            var result = conn.Query<SecKey>("SELECT * FROM security", buffered: false);
            var list = new List<SecKey>();
            foreach (var sec in result)
            {
                list.Add(sec);
            }
            conn.Close();
        }

        [Benchmark]
        [BenchmarkCategory("Buffered")]
        public void Scenario2()
        {
            using var conn = new VfpConnection();
            conn.ConnectionString = "Provider=VFPOLEDB.1;Data Source=.\\Data";
            conn.Open();
            var result = conn.Query<SecKey>("SELECT * FROM security", buffered: true);
            var list = new List<SecKey>();
            foreach (var sec in result)
            {
                list.Add(sec);
            }
            conn.Close();
        }
    }
}
