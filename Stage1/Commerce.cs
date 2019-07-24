using System;
using DependencyInjectionDemo2;

namespace Stage1
{
  internal class Commerce
  {    
    internal void ProcessOrder(OrderInfo orderInfo)
    {
      BillingProcessor billingProcessor = new BillingProcessor();
      CustomerProcessor customerProcessor = new CustomerProcessor();
      Notifier notifier = new Notifier();

      billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
      customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
      notifier.SendReceipt(orderInfo);
    }
  }
}