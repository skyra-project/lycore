# LyCore

[Skyra VI]'s microservice server. It is subdivided in two parts:

1. **Ryana**: A fast multithreaded image rendering server powered by [Magick.NET].
1. **NeuLink**: A multithreaded game AI server.

[Skyra VI]: https://github.com/kyranet/lyrch
[Magick.NET]: https://github.com/dlemstra/Magick.NET

## Development Requirements

- [.NET Core 3.0]: To build and run the project.
- [Resharper]: (Dev Optional) To lint the project, this only works on Windows - this is not a requirement but a
nice-to-have feature.

[.NET Core 3.0]: https://dotnet.microsoft.com/download/dotnet-core/3.0
[Resharper]: https://www.jetbrains.com/resharper/

## Set-Up

```bash
# Builds the project
$ dotnet build

# Run the project
$ dotnet run
```

> **Note**: Before pushing to the repository, it is suggested to run Resharper, but it is fine if you do not do so, the
CI will catch any issue it finds.

## NyProject Network

LyCore does not depend on any component, but rather is a dependent of:

- [`Lyrch`]: A lightning fast Discord Bot written in Rust.

[`Lyrch`]: https://github.com/kyranet/Lyrch
