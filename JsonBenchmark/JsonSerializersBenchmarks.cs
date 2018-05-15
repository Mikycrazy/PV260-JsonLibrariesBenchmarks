using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;
using ServiceStack;

namespace JsonBenchmark
{
  [ClrJob(isBaseline: true)]
  [RPlotExporter, RankColumn]
  [HtmlExporter]
  public class JsonSerializersBenchmarks : JsonBenchmarkBase
  {
    private Root root;

    [GlobalSetup]
    public void GlobalSetup()
    {
      root = JsonConvert.DeserializeObject<Root>(JsonSampleString);
    }

    [Benchmark]
    public string NewtonsoftJson_Serialize()
    {
      return JsonConvert.SerializeObject(root, Formatting.Indented);
    }

    [Benchmark]
    public string ServiceStack_Serialize()
    {
      return root.ToJson();
    }
  }
}