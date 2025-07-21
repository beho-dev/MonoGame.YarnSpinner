using Microsoft.Xna.Framework.Content.Pipeline;
using Moq;
using Xunit;

namespace MonoGame.YarnSpinner.Tests;

public class YarnProcessorTests
{
    [Fact]
    public void Process_WithValidYarnFile_CreatesCompiledProgram()
    {
        // Arrange
        var processor = new YarnProcessor();
        var yarnScript = File.ReadAllText("Assets/TestDialogue.yarn");
        var mockContext = new Mock<ContentProcessorContext>();

        // Act
        var result = processor.Process(yarnScript, mockContext.Object);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Program);
        Assert.NotNull(result.StringTable);
        Assert.Equal(2, result.StringTable.Count);
        Assert.Contains("Player: Hello, this is the Start node.", result.StringTable.Values);
        Assert.Contains("NPC: And this is the second node.", result.StringTable.Values);
    }
}
