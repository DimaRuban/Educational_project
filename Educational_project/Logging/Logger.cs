using StorePhone.Сontracts;

namespace StorePhone.Logging
{
    public class Logger : ILogger
    {
         private readonly IFileManager _fileManager;

         public Logger(IFileManager fileManager)
         {
             _fileManager = fileManager;
         }
         public void Log(string message)
         {
             _fileManager.WorkWithFiles(message);
         }
    }
}