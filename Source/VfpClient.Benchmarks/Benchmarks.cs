using BenchmarkDotNet.Attributes;
using Dapper;
using MapDataReader;
using System.Collections.Generic;

namespace VfpClient.Benchmarks;

public class Benchmarks
{
    public Benchmarks()
    {
    }

    [Benchmark]
    [BenchmarkCategory("Dapper")]
    public void DapperUnbuffered()
    {
        using var conn = new VfpConnection();
        conn.ConnectionString = "Provider=VFPOLEDB.1;Data Source=C:\\FVL\\IDMS\\Data\\Databases\\FVL001\\FVL001.DBC;";
        conn.Open();
        var result = conn.Query<PreservationWorkOrder>("SELECT * FROM preswo", buffered: false);
        var list = new List<PreservationWorkOrder>();
        foreach (var pwo in result)
        {
            list.Add(pwo);
        }
        conn.Close();
    }

    [Benchmark]
    [BenchmarkCategory("Dapper")]
    public void DapperBuffered()
    {
        using var conn = new VfpConnection();
        conn.ConnectionString = "Provider=VFPOLEDB.1;Data Source=C:\\FVL\\IDMS\\Data\\Databases\\FVL001\\FVL001.DBC;";
        conn.Open();
        var result = conn.Query<PreservationWorkOrder>("SELECT * FROM preswo", buffered: true);
        var list = new List<PreservationWorkOrder>();
        foreach (var pwo in result)
        {
            list.Add(pwo);
        }
        conn.Close();
    }

    [Benchmark]
    [BenchmarkCategory("MapDataReader")]
    public void MapDataReaderToList()
    {
        using var conn = new VfpConnection();
        conn.ConnectionString = "Provider=VFPOLEDB.1;Data Source=C:\\FVL\\IDMS\\Data\\Databases\\FVL001\\FVL001.DBC;";
        conn.Open();
        var result = conn.ExecuteReader("SELECT * FROM preswo").ToPreservationWorkOrder();
        var list = new List<PreservationWorkOrder>();
        foreach (var pwo in result)
        {
            list.Add(pwo);
        }
        conn.Close();
    }

    [Benchmark]
    [BenchmarkCategory("MapDataReader")]
    public void MapDataReaderOnly()
    {
        using var conn = new VfpConnection();
        conn.ConnectionString = "Provider=VFPOLEDB.1;Data Source=C:\\FVL\\IDMS\\Data\\Databases\\FVL001\\FVL001.DBC;";
        conn.Open();
        var result = conn.ExecuteReader("SELECT * FROM preswo").ToPreservationWorkOrder();
        conn.Close();
    }
}
