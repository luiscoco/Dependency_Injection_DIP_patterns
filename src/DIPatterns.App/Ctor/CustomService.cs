using System;

namespace DIPatterns.App.Ctor;

public interface IDependency
{
    void DoSomething();
}

public class Dependency : IDependency
{
    public void DoSomething() => throw new System.NotImplementedException();
}

public class CustomService
{
    private readonly IDependency _dependency;

    public CustomService(IDependency dependency) =>
        _dependency = dependency
                      ?? throw new ArgumentNullException(nameof(dependency));

    public void DoSomeWork() => _dependency.DoSomething();
}