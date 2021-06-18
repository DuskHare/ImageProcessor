``` ini

BenchmarkDotNet=v0.12.1.1514-nightly, OS=Windows 10.0.19043
11th Gen Intel Core i5-11600K 3.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.204
  [Host]       : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT  [AttachedDebugger]
  .Net 5.0 CLI : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT

Job=.Net 5.0 CLI  Arguments=/p:DebugType=portable  Toolchain=.NET 5.0  
IterationCount=5  LaunchCount=1  WarmupCount=5  

```
|                                Method |      Mean |     Error |   StdDev | Ratio | RatioSD |     Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|-------------------------------------- |----------:|----------:|---------:|------:|--------:|----------:|----------:|----------:|----------:|
|   &#39;System.Drawing Load, Resize, Save&#39; | 338.81 ms |  7.374 ms | 1.915 ms |  1.00 |    0.00 |         - |         - |         - |     12 KB |
|       &#39;ImageSharp Load, Resize, Save&#39; | 137.07 ms | 18.454 ms | 2.856 ms |  0.41 |    0.01 |         - |         - |         - |  1,990 KB |
|      &#39;ImageMagick Load, Resize, Save&#39; | 347.48 ms | 62.681 ms | 9.700 ms |  1.03 |    0.03 |         - |         - |         - |     54 KB |
|        &#39;ImageFree Load, Resize, Save&#39; | 211.53 ms | 16.421 ms | 4.265 ms |  0.62 |    0.01 | 6000.0000 | 6000.0000 | 6000.0000 |     91 KB |
|      &#39;MagicScaler Load, Resize, Save&#39; |  64.69 ms |  9.419 ms | 1.458 ms |  0.19 |    0.00 |         - |         - |         - |    102 KB |
| &#39;SkiaSharp Canvas Load, Resize, Save&#39; | 169.82 ms | 19.078 ms | 4.955 ms |  0.50 |    0.01 |         - |         - |         - |    103 KB |
| &#39;SkiaSharp Bitmap Load, Resize, Save&#39; | 167.27 ms | 17.453 ms | 4.532 ms |  0.49 |    0.01 |         - |         - |         - |     87 KB |
|          &#39;NetVips Load, Resize, Save&#39; | 143.29 ms | 24.006 ms | 6.234 ms |  0.42 |    0.02 |         - |         - |         - |     47 KB |
