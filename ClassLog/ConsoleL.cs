using InterfaceLibrary;


namespace ClassLog
{
    public class ConsoleLog : ILog
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
