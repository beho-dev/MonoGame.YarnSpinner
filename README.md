# MonoGame.YarnSpinner

A reusable MonoGame Content Pipeline extension for importing and processing Yarn Spinner files (`.yarn`).

This library provides the necessary `Importer`, `Processor`, `Writer`, and `Reader` to allow `.yarn` script files to be processed directly by the MonoGame Content Pipeline (MGCB), making dialogue integration seamless.

## Features

-   **Content Importer:** `YarnImporter` reads `.yarn` files.
-   **Content Processor:** `YarnProcessor` compiles the Yarn script into a `Program` and `StringTable`.
-   **Content Type Writer/Reader:** `YarnWriter` and `YarnReader` handle writing and reading the compiled program to/from the binary `.xnb` format.

## Usage

1.  Reference this project in your MonoGame project.
2.  Add your `.yarn` files to your `Content.mgcb` file.
3.  Set the Importer to `YarnImporter - MonoGame.YarnSpinner`.
4.  Set the Processor to `YarnProcessor - MonoGame.YarnSpinner`.
5.  Load your compiled Yarn scripts in-game using:
    ```csharp
    var compiledScript = Content.Load<CompiledYarnProgram>("MyYarnScript");
    ```

## Build Configuration

This project includes a custom MSBuild target to solve a dependency issue with the MonoGame Content Builder (MGCB).

The `YarnProcessor` needs access to the `YarnSpinner.Compiler.dll` and its dependencies at build time to compile `.yarn` scripts. However, MGCB runs in a separate process and does not automatically resolve NuGet dependencies for content processors.

To fix this, the `.csproj` file for this project contains a custom target named `CopyYarnCompilerToOutput`. This target runs after every build and explicitly copies the required Yarn Spinner DLLs from the NuGet package cache into this project's output directory (`bin/Debug` or `bin/Release`). This ensures that when MGCB invokes the processor, all necessary assemblies are available in the location it expects to find them. 