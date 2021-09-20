using StorePhone.Сontract;

namespace StorePhone.Logging
{
    public class Logger : ILogger
    {
         public void Log(string message)
         {
             FileManager.Write(message);
         }
    }
}