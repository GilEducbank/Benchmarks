``` ini

BenchmarkDotNet=v0.13.2, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro 2.40GHz, 1 CPU, 8 logical and 8 physical cores
  [Host]     : Mono 6.12.0.182 (2020-02/6051b710727 Tue), X64 VectorSize=128
  DefaultJob : Mono 6.12.0.182 (2020-02/6051b710727 Tue), X64 VectorSize=128


```
|        Method |       Mean |    Error |   StdDev |      Gen0 |     Gen1 |     Gen2 | Allocated |
|-------------- |-----------:|---------:|---------:|----------:|---------:|---------:|----------:|
|    MemoResult | 4,930.9 μs | 62.47 μs | 58.43 μs | 2156.2500 | 265.6250 | 265.6250 |         - |
| MemoTwoResult | 2,751.7 μs | 34.18 μs | 30.30 μs | 2316.4063 |        - |        - |         - |
|    LogNResult |   188.2 μs |  0.83 μs |  0.73 μs |   23.4375 |        - |        - |         - |
