using Autofac;

namespace DIPatterns.App.DesignSamples;

public class ClassWithServiceLocator
{
    private readonly ISmartTracer _smartTracer;
    private readonly INotifier _notifier;
    private readonly IViewModelBase _viewModelBase;
    private readonly IRepository _repository;
    private readonly ILogger _logger;

    public ClassWithServiceLocator(IContainer container)
    {
        _logger = container.Resolve<ILogger>();
        _smartTracer = container.Resolve<ISmartTracer>();
        _notifier = container.Resolve<INotifier>();
        _viewModelBase = container.Resolve<IViewModelBase>();
        _repository = container.Resolve<IRepository>();
    }
}

internal interface IViewModelBase
{
}

internal interface INotifier
{
}

internal interface ISmartTracer
{
}

internal interface ILogger
{
}