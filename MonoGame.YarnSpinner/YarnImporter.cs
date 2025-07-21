using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MonoGame.YarnSpinner;

/// <summary>
/// The first stage of the content pipeline for Yarn scripts.
/// This class is responsible for importing a `.yarn` file from disk
/// and passing its raw text content to the next stage, the <see cref="YarnProcessor"/>.
/// </summary>
[ContentImporter(
    ".yarn",
    DisplayName = "Yarn Importer - MonoGame.YarnSpinner",
    DefaultProcessor = "YarnProcessor"
)]
public class YarnImporter : ContentImporter<string>
{
    /// <summary>
    /// Imports a `.yarn` file.
    /// </summary>
    /// <param name="filename">The full path to the `.yarn` file.</param>
    /// <param name="context">The context for the content importer.</param>
    /// <returns>The raw text content of the file.</returns>
    public override string Import(string filename, ContentImporterContext context)
    {
        return File.ReadAllText(filename);
    }
}
