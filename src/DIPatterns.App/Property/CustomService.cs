namespace DIPatterns.App.Property;

// Dependency.dll
public interface IDependency
{ }

// CustomService.dll (!)
public class DefaultDependency : IDependency
{ }

// FancyService.dll
public class NonDefaultDependency : IDependency
{ }

// CustomService.dll
public class CustomService
{
    public CustomService()
    {
        Dependency = new DefaultDependency();
    }
    //
    //try to replace set with init and observe what happens
    //
    public IDependency Dependency { get; set; }     
}