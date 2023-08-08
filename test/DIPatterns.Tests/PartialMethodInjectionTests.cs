using Autofac;
using DIPatterns.App.Method;
using FluentAssertions;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DIPatterns.Tests;

public class PartialMethodInjectionTests
{
    private readonly ITestOutputHelper _output;
    public PartialMethodInjectionTests(ITestOutputHelper output) => _output = output;

    [Fact]
    public void Test_Partial_Application()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<DefaultReportFormatter>().AsImplementedInterfaces();

        var container = builder.Build();

        Func<IReportFormatter, double, string> createReportWithFormatter =
            ReportService.CreateReport;

        /*
        //actually, is an anti-pattern as we capture container
        */

        Func<double, string> createReport =
            d => createReportWithFormatter(container.Resolve<IReportFormatter>(), d);


        string report = createReport(42);


        report.Should().NotBeNullOrWhiteSpace();
        _output.WriteLine(report);
    }
}