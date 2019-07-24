using static System.Console;

namespace Stage2
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