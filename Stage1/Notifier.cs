using System;
using DependencyInjectionDemo2;

namespace Stage1
{
  internal class Notifier
  {
    internal void SendReceipt(OrderInfo orderInfo)
    {
      Console.WriteLine($"Order receipt has been sent to Customer - {orderInfo.CustomerName} via email.");
    }
  }
}