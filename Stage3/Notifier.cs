using System;
using DependencyInjectionDemo2;

namespace Stage3
{
  internal class Notifier: INotifier
  {
    void INotifier.SendReceipt(OrderInfo orderInfo)
    {
      Console.WriteLine($"Order receipt has been sent to Customer - {orderInfo.CustomerName} via email.");
    }
  }
  internal interface INotifier
  {
    void SendReceipt(OrderInfo orderInfo);
  }
}