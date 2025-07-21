using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Yarn;

namespace MonoGame.YarnSpinner;

/// <summary>
/// Reads a compiled Yarn program from a .xnb file.
/// This is the runtime component of the Yarn Spinner content pipeline extension.
/// It reconstructs the <see cref="CompiledYarnProgram"/> that was processed
/// and written by the <see cref="YarnWriter"/>.
/// </summary>
public class YarnReader : ContentTypeReader<CompiledYarnProgram>
{
    /// <summary>
    /// Reads a compiled Yarn program from the binary format.
    /// </summary>
    /// <param name="input">The content reader.</param>
    /// <param name="existingInstance">An existing object to reuse.</param>
    /// <returns>A new <see cref="CompiledYarnProgram"/> instance.</returns>
    /// <remarks>
    /// The binary format is structured as follows:
    /// 1. An integer (int32) specifying the length of the protobuf byte array for the Yarn Program.
    /// 2. The protobuf byte array for the Yarn Program.
    /// 3. The string table, written as a generic IDictionary&lt;string, string&gt; using the content writer's built-in object serialization.
    /// </remarks>
    protected override CompiledYarnProgram Read(
        ContentReader input,
        CompiledYarnProgram? existingInstance
    )
    {
        // Read the compiled Yarn program (a protobuf message)
        var programLength = input.ReadInt32();
        var programData = input.ReadBytes(programLength);
        var program = Program.Parser.ParseFrom(programData);

        // Read the string table
        var stringTable = input.ReadObject<IDictionary<string, string>>();

        return new CompiledYarnProgram { Program = program, StringTable = stringTable };
    }
}
