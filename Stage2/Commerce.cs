using System;
using DependencyInjectionDemo2;

namespace Stage2
{
  internal class Commerce
  {
    IBillingProcessor _billingProcessor;
    ICustomerProcessor _customerProcessor;
    INotifier _notifier;

    public Commerce(IBillingProcessor billingProcessor, ICustomerProcessor customerProcessor, INotifier notifier)
    {
      _billingProcessor = billingProcessor;
      _customerProcessor = customerProcessor;
      _notifier = notifier;
    }
    internal void ProcessOrder(OrderInfo orderInfo)
    {
      _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
      _customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
      _notifier.SendReceipt(orderInfo);
    }
  }
}