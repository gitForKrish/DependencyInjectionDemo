using Autofac;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace DependencyInjectionDemo2
{
  // What is IoC and DI?
  /*
   * IoC is a generic term meaning rather than having the application call the methods in a framework, 
   * the framework calls implementations provided by the application.
   * 
   * DI is a form of IoC, where implementations are passed into an object through constructors/setters/service lookups,
   * which the object will 'depend' on in order to behave correctly.
   */

  // Why Dependency Injection or Inversion of Control (IoC)?
  /*
   * It solves two problems - Testability and Dependencies resolution.
   * Dependency Injection (DI) is an architectural design pattern. DI Container is a product (Autofac,  Unity, Ninject etc.). 
   */
  static class DependencyInjection
  {
    static IContainer Container;
    static void Main()
    {
      var exit = false;
      while (!exit)
      {
        WriteLine();
        WriteLine("1 - Stage 1");
        WriteLine("2 - Stage 2");
        WriteLine("3 - Stage 3");
        WriteLine("0 - Exit ");
        WriteLine();

        WriteLine("Select demo: ");
        var choice = ReadLine();
        if (choice == "0")
          exit = true;
        else
        {
          var orderInfo = new OrderInfo()
          {
            CustomerName = "Stanley Copper",
            Email = "stanley.copper@abc.com",
            Product = "Laptop",
            Price = 65000.50,
            CreditCard = "12345678"
          };

          WriteLine();
          WriteLine("Order processing ... ");
          WriteLine();

          switch (choice)
          {
            case "1": // This approach of development is not unit-testable as there are many local dependencies.
              Stage1.Commerce commerce1 = new Stage1.Commerce();
              commerce1.ProcessOrder(orderInfo);
              break;

            case "2": // This approach is easily unit-testable with Mocking framework, but introducing new dependency to any level is costly
              Stage2.Commerce commerce2 =
                new Stage2.Commerce(
                    new Stage2.BillingProcessor(),
                    new Stage2.CustomerProcessor(
                        new Stage2.CustomerRepository(),
                        new Stage2.ProductRepository()),
                    new Stage2.Notifier());
              commerce2.ProcessOrder(orderInfo);
              break;

            case "3": // With DI Container (AutoFac) - Two Steps: Register and Resolve
              // DI Container takes care of all the instantiation
              // Register at global place like Global.asax for Web Application
              
              ContainerBuilder builder = new ContainerBuilder();

              builder.RegisterType<Stage3.Commerce>();
              builder.RegisterType<Stage3.Notifier>().As<Stage3.INotifier>();

              builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Processor") && t.Namespace.EndsWith("Stage3"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

              builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository") && t.Namespace.EndsWith("Stage3"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

              Container = builder.Build();
              var commerce3 = Container.Resolve<Stage3.Commerce>();
              commerce3.ProcessOrder(orderInfo);
              break;
          }
        }
      }
    }
  }
}
