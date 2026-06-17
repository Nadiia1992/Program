using System;
using System.Collections.Generic;
using InterfaceLibrary;


namespace ClassLog
{
    public class FileLog : ILog
    {
        public void Print(string message)
        {
            File.AppendAllText("log.txt", message +  Environment.NewLine);
        }

    }
}
