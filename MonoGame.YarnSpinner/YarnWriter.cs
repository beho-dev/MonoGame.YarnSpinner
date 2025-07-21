using Google.Protobuf;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace MonoGame.YarnSpinner;

/// <summary>
/// The third and final stage of the content pipeline for Yarn scripts.
/// This class takes the <see cref="CompiledYarnProgram"/> produced by the
/// <see cref="YarnProcessor"/> and writes it into a binary `.xnb` file.
/// The corresponding runtime reader is the <see cref="YarnReader"/>.
/// </summary>
[ContentTypeWriter]
public class YarnWriter : ContentTypeWriter<CompiledYarnProgram>
{
    /// <inheritdoc/>
    public override string GetRuntimeReader(TargetPlatform targetPlatform)
    {
        return "MonoGame.YarnSpinner.YarnReader, MonoGame.YarnSpinner";
    }

    /// <summary>
    /// Writes the compiled Yarn program to the binary output.
    /// </summary>
    /// <param name="output">The content writer.</param>
    /// <param name="value">The <see cref="CompiledYarnProgram"/> to write.</param>
    protected override void Write(ContentWriter output, CompiledYarnProgram value)
    {
        var programBytes = value.Program.ToByteArray();
        output.Write(programBytes.Length);
        output.Write(programBytes);

        output.WriteObject(value.StringTable);
    }
}
