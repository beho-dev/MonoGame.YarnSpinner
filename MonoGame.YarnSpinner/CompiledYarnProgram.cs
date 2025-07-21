using System.Collections.Generic;
using Yarn;

namespace MonoGame.YarnSpinner;

/// <summary>
/// Represents a compiled Yarn script, containing both the program logic
/// and the associated string table. This is the runtime object that gets
/// loaded from a .xnb file.
/// </summary>
public class CompiledYarnProgram
{
    /// <summary>
    /// Gets or sets the compiled Yarn program.
    /// </summary>
    public Program Program { get; set; }

    /// <summary>
    /// Gets or sets the mapping of line IDs to their corresponding text.
    /// </summary>
    public IDictionary<string, string>? StringTable { get; set; }
}
