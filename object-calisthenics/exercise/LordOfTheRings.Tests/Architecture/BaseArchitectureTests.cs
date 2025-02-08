using FluentAssertions;

namespace LordOfTheRings.Tests.Architecture;

public class BaseArchitectureTests
{
    [Fact]
    public void Should_Pass()
    {
        true.Should().BeTrue();
    }
}