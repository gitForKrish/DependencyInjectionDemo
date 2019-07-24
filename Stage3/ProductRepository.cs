using static System.Console;

namespace Stage3
{
  internal class ProductRepository: IProductRepository
  {
    void IProductRepository.Save() => WriteLine("Product record saved.");
  }
  interface IProductRepository
  {
    void Save();
  }
}