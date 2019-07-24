using static System.Console;

namespace Stage3
{
  internal class CustomerProcessor: ICustomerProcessor
  {
    ICustomerRepository _customerRepository;
    IProductRepository _productRepository;
    public CustomerProcessor(ICustomerRepository customerRepository, IProductRepository productRepository)
    {
      _customerRepository = customerRepository;
      _productRepository = productRepository;
    }
    void ICustomerProcessor.UpdateCustomerOrder(string customerName, string product)
    {
      _customerRepository.Save();
      _productRepository.Save();

      WriteLine($"Customer record for {customerName} updated with product record {product}");
    }
  }

  internal interface ICustomerProcessor
  {
    void UpdateCustomerOrder(string customerName, string product);
  }
}