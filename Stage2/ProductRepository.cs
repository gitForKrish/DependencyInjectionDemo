using static System.Console;

namespace Stage2
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