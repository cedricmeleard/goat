using LordOfTheRings.App;

namespace LordOfTheRings.Tests;

public class GoldenMasterTests
{
    [Fact]
    public async Task Should_Resist_Refactoring()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Program.Run();

        // Assert: Utiliser Verify pour vérifier la sortie
        string output = stringWriter.ToString();
        await Verify(output);
    }
}