using System;
using System.Runtime.Serialization;
using System.Text;
using InterfaceLibrary;


namespace ClassLibrary
{
    [Serializable]
    [DataContract]
    public class Flash : Storage
    {
        [DataMember]
        public int SpeedUSB { get; set; }

        public Flash(string manufacturer, string model, string name, int capacity, int quantity, int speedusb) : 
            base(manufacturer, model, name, capacity, quantity)
        {
            Type = "Flash";
            SpeedUSB = speedusb;
        }

        public Flash() { }

        public override void Print(ILog logger)
        {
            base.Print(logger);
            logger.Print("Швидкість USB: " + SpeedUSB);
        }
    }
   
}
