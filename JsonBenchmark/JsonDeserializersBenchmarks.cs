using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;
using ServiceStack;
using System;
using System.IO;

namespace JsonBenchmark
{
  [ClrJob(isBaseline: true)]
  [RPlotExporter, RankColumn]
  [HtmlExporter]
  public class JsonDeserializersBenchmarks : JsonBenchmarkBase
  {
    [Benchmark]
    public Root NewtonsoftJson_Deserialize_ChuckNorris()
    {
      var JsonSampleString = File.ReadAllText(ChucknorrisJsonPath);
      return JsonConvert.DeserializeObject<Root>(JsonSampleString);
    }

    [Benchmark]
    public Root ServiceStack_Deserialize_ChuckNorris()
    {
      var JsonSampleString = File.ReadAllText(ChucknorrisJsonPath);
      return JsonSampleString.FromJson<Root>();
    }

    [Benchmark]
    public Root NewtonsoftJson_Deserialize_ChuckNorris_StreamReader()
    {
      using (StreamReader sr = new StreamReader(ChucknorrisJsonPath))
      using (JsonReader reader = new JsonTextReader(sr))
      {
        JsonSerializer serializer = new JsonSerializer();
        return serializer.Deserialize<Root>(reader);
      }
    }

    [Benchmark]
    public Book[] NewtonsoftJson_Deserialize_LotrBook()
    {
      var LordOfTheRingsBookJsonSampleString = File.ReadAllText(LordOfTheRingsBookJsonPath);
      return JsonConvert.DeserializeObject<Book[]>(LordOfTheRingsBookJsonSampleString);
    }

    [Benchmark]
    public Book[] NewtonsoftJson_Deserialize_LotrBook_Optimalized()
    {
      using (StreamReader sr = new StreamReader(LordOfTheRingsBookJsonPath))
      using (JsonReader reader = new JsonTextReader(sr))
      {
        JsonSerializer serializer = new JsonSerializer();
        return serializer.Deserialize<Book[]>(reader);
      }
    }

    [Benchmark]
    public Book[] ServiceStack_Deserialize_LotrBook()
    {
      var LordOfTheRingsBookJsonSampleString = File.ReadAllText(LordOfTheRingsBookJsonPath);
      return LordOfTheRingsBookJsonSampleString.FromJson<Book[]>();
    }
  }
}
