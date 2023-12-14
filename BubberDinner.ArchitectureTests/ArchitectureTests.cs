using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace BubberDinner.ArchitectureTests;

public class ArchitectureTests
{
    private const string ApplicationNamespace = "BubberDinner.Application";
    private const string ApiNamespace = "BubberDinner.Api";
    private const string DomainNamespace = "BubberDinner.Domain";
    private const string InfrustructureNamespace = "BubberDinner.Infrustructure";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        var assembly = typeof(Domain.User.User).Assembly;

        var otherProjects = new[]
        {
            ApiNamespace,
            InfrustructureNamespace,
            ApplicationNamespace,   
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Only_HaveDependencyOnDomainProject()
    {
        var assembly = typeof(Application.Authentication.Commands.Register.RegisterCommand).Assembly;

        var otherProjects = new[]
        {
            ApiNamespace,
            InfrustructureNamespace,
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

}
