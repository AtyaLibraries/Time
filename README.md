# Time

`Time` is the repository for the `Atya.Foundation.Time` NuGet package.

| | |
| --- | --- |
| Repository | [https://github.com/AtyaLibraries/Time](https://github.com/AtyaLibraries/Time) |
| NuGet | `Atya.Foundation.Time` |
| License | MIT |

This package provides UTC-safe abstractions for reading the current time and for
validating UTC-only inputs in low-level APIs.

## Included APIs

- `IClock`
- `SystemClock`
- `TimeGuard.AgainstNonUtc`

## Layout

```text
.
|-- src/Time/
|-- tests/Time.UnitTests/
|-- samples/Time.Samples.Console/
|-- benchmarks/Time.Benchmarks/
`-- .github/
```

## Build, Test, Pack

```bash
dotnet restore ./Time.sln
dotnet build ./Time.sln --configuration Release --no-restore
dotnet test ./tests/Time.UnitTests/Time.UnitTests.csproj --configuration Release --no-build
dotnet pack ./src/Time/Time.csproj --configuration Release --no-build
```

Artifacts land in `artifacts/packages/`.
