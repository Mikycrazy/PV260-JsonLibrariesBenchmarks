using System;
using System.IO;

namespace JsonBenchmark
{
  public abstract class JsonBenchmarkBase
  {
    protected const string TestFilesFolder = "TestFiles";
    protected string ChucknorrisJsonPath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");
    protected string LordOfTheRingsBookJsonPath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "LordOfTheRingsBook.json");
    public string JsonSampleString { get; }

    protected JsonBenchmarkBase()
    {
      JsonSampleString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json"));
    }

  }
}
