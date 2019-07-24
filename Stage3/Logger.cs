using static System.Console;

namespace Stage3
{
  internal class Logger : ILogger
  {
    void ILogger.Log(string message)
    {
      WriteLine($"Message logged - {message}");
    }
  }
  internal interface ILogger
  {
    void Log(string customerName);
  }
}