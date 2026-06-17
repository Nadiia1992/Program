using System;
using System.Runtime.Serialization;
using System.Text;
using InterfaceLibrary;

namespace ClassLibrary
{
    [Serializable]
    [DataContract]

    public class DVD : Storage
    {
 
        [DataMember]
        public int WriteSpeed { get; set; }

        public DVD(string manufacturer, string model, string name, int capacity, int quantity, int writespeed) 
            : base(manufacturer, model, name, capacity, quantity)
        {
            WriteSpeed = writespeed;
            Type = "DVD";
        }
        public DVD()
        {
            Type = "DVD";
        }
        public override void Print(ILog logger)
        {
            base.Print(logger);
            logger.Print("Швидкість запису: "+ WriteSpeed);
        }
    }
}