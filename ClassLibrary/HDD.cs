using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using InterfaceLibrary;


namespace ClassLibrary
{
    [Serializable]
    [DataContract]
    public class HDD : Storage
    {
        [DataMember]
        public int SpeedHDD { get; set; }

        public HDD(string manufacturer, string model, string name, int capacity, int quantity, int speedhdd) 
            : base(manufacturer, model, name, capacity, quantity)
        {
            Type = "HDD";
            SpeedHDD = speedhdd;
        }

        public HDD()
        {
            Type = "HDD";
        }
        public override void Print(ILog logger)
        {
            base.Print(logger);
            logger.Print("Швидкість роботи: "+ SpeedHDD);
        }
    }
         
}
