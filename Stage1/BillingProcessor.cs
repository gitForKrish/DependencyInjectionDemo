using static System.Console;

namespace Stage1
{
  internal class BillingProcessor
  {
    internal void ProcessPayment(string customerName, string creditCard, double price)
    {
      WriteLine($"Customer - {customerName} has successfully paid {price}.");
    }
  }
}