using Microsoft.Xna.Framework.Content.Pipeline;
using Yarn.Compiler;

namespace MonoGame.YarnSpinner;

/// <summary>
/// The second stage of the content pipeline for Yarn scripts.
/// This class receives the raw text from the <see cref="YarnImporter"/>,
/// compiles it using the <see cref="Yarn.Compiler.Compiler"/>, and prepares
/// it for serialization by the <see cref="YarnWriter"/>.
/// </summary>
[ContentProcessor(DisplayName = "Yarn Processor - MonoGame.YarnSpinner")]
public class YarnProcessor : ContentProcessor<string, CompiledYarnProgram>
{
    /// <summary>
    /// Compiles a raw Yarn script into a <see cref="CompiledYarnProgram"/>.
    /// </summary>
    /// <param name="input">The raw text of the Yarn script.</param>
    /// <param name="context">The context for the content processor.</param>
    /// <returns>A <see cref="CompiledYarnProgram"/> containing the compiled program and string table.</returns>
    public override CompiledYarnProgram Process(string input, ContentProcessorContext context)
    {
        var compilationJob = CompilationJob.CreateFromString("input", input);
        var compilationResult = Compiler.Compile(compilationJob);

        var compiledProgram = new CompiledYarnProgram
        {
            Program = compilationResult.Program,
            StringTable = compilationResult.StringTable.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.text
            ),
        };

        return compiledProgram;
    }
}
