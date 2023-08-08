using Autofac;
using DIPatterns.App.Property;
using FluentAssertions;
using Xunit;

namespace DIPatterns.Tests;

public class PropertyInjectionTests
{
    [Fact]
    public void Test_PropertyInjectionSetter()
    {
        #region composition root
        var builder = new ContainerBuilder();
        builder.RegisterType<NonDefaultDependency>().AsImplementedInterfaces();
        builder
            .RegisterType<CustomService>()
            .AsSelf()
            .OnActivated(args => args.Instance.Dependency = args.Context.Resolve<IDependency>())
            .InstancePerLifetimeScope();
        #endregion composition root

        var container = builder.Build();
        var customService = container.Resolve<CustomService>();

        customService.Dependency.Should().NotBeNull()
            .And.BeOfType<NonDefaultDependency>();

        customService.Dependency = container.Resolve<IDependency>();
    }
}