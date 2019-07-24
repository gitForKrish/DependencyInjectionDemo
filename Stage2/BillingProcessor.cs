using static System.Console;

namespace Stage2
{
  internal class BillingProcessor : IBillingProcessor
  {
    void IBillingProcessor.ProcessPayment(string customerName, string creditCard, double price)
    {
      WriteLine($"Customer - {customerName} has successfully paid {price}.");
    }
  }
  internal interface IBillingProcessor
  {
    void ProcessPayment(string customerName, string creditCard, double price);
  }
}