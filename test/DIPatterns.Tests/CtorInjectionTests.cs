using Autofac;
using DIPatterns.App.Ctor;
using FluentAssertions;
using Xunit;

namespace DIPatterns.Tests;

public class CtorInjectionTests
{
    [Fact]
    public void Resolve_WithConstructorInjection_GetInstance()
    {
        #region composition root
        var builder = new ContainerBuilder();
        builder.RegisterType<Dependency>().AsImplementedInterfaces();
        builder.RegisterType<CustomService>().AsSelf();

        var container = builder.Build();
        #endregion composition root


        var customService = container.Resolve<CustomService>();

        customService.Should().NotBeNull();
        //customService.DoSomeWork();
    }
}