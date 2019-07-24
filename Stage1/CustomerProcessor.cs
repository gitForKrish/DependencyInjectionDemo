using static System.Console;

namespace Stage1
{
  internal class CustomerProcessor
  {
    internal void UpdateCustomerOrder(string customerName, string product)
    {
      CustomerRepository customerRepository = new CustomerRepository();
      ProductRepository productRepository = new ProductRepository();

      customerRepository.Save();
      productRepository.Save();

      WriteLine($"Customer record for {customerName} updated with product record {product}");
    }
  }
}