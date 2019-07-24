using static System.Console;

namespace Stage3
{
  internal class CustomerRepository : ICustomerRepository
  {
    void ICustomerRepository.Save() => WriteLine("Customer purchase saved.");
  }
  interface ICustomerRepository
  {
    void Save();
  }
} 