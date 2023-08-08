using System;
using System.Threading;
using System.Windows.Input;

namespace DIPatterns.App;

class Program
{
    static void Main(string[] args)
    {
        // Using context to send data into another thread
        var context = new CustomViewModel();
        var thread = new Thread(o =>
        {
            var localContext = (CustomViewModel)o;
        });
        thread.Start(context);
        Console.WriteLine("App running!");
    }
}

internal class CustomViewModel
{
}

internal class RelayCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object parameter)
    {
        throw new NotImplementedException();
    }
}

internal class Money
{
}

public interface ICurrencyRate
{
    int GetCurrencyRate(string currency);
}

internal class PaymentService
{
    public static Money CalculatePayment(ICurrencyRate currencyRate)
    {
        return new Money();
    }
}