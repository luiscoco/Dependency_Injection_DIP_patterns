namespace DIPatterns.App.Method;

/// <summary>
/// Defines report formatting strategy
/// </summary>
public interface IReportFormatter
{
    string GetFormatString();
}

public class DefaultReportFormatter : IReportFormatter
{
    public string GetFormatString() => "$1";
}

public class ReportService
{
    public static string CreateReport(IReportFormatter reportFormatter, double data)
    {
        return $"{reportFormatter.GetFormatString()} {data}";
    }
}