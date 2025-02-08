using System.Reflection;
using LordOfTheRings.App;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Infrastructure.Adapters;

namespace LordOfTheRings.Tests.Architecture.Infrastructure;

public abstract class BaseTests
{
    protected readonly Assembly ApplicationAssembly = typeof(Program).Assembly;
    protected readonly Assembly DomainAssembly = typeof(Fellowship).Assembly;
    protected readonly Assembly InfrastructureAssembly = typeof(FellowshipPresenter).Assembly;
}