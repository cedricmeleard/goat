using FluentAssertions;
using LordOfTheRings.Tests.Architecture.Infrastructure;
using NetArchTest.Rules;

namespace LordOfTheRings.Tests.Architecture.Layers;

public class BaseArchitectureTests : BaseTests
{
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_OtherLayers()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOnAll(
                ApplicationAssembly.GetName().Name,
                InfrastructureAssembly.GetName().Name
            )
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureLayer_ShouldNotHaveDependencyOn_ApplicationLayer()
    {
        var result = Types
            .InAssembly(InfrastructureAssembly)
            .Should()
            .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}