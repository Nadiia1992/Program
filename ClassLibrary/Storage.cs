using System;
using System.Numerics;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using InterfaceLibrary;

namespace ClassLibrary
{
    [Serializable]
    [KnownType(typeof(Flash))]
    [KnownType(typeof(DVD))]
    [KnownType(typeof(HDD))]
    [XmlInclude(typeof(Flash))]
    [XmlInclude(typeof(DVD))]
    [XmlInclude(typeof(HDD))]
    [DataContract]
    public abstract class Storage
    {
        [DataMember]
        public string? Type { get; set; }

        [DataMember]
        public string NameManufacturer { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Capacity { get; set; }

        [DataMember]
        public int Quantity { get; set; }


        public Storage(string manufacturer, string model, string name, int capacity, int quantity)
        {
            NameManufacturer = manufacturer;
            Model = model;
            Name = name;
            Capacity = capacity;
            Quantity = quantity;

        }

        public Storage() { }

        public virtual void Print(ILog logger)
        {
            logger.Print($"Тип: {GetType().Name} | Назва виробника: {NameManufacturer} | Модель: {Model} | Наіменування: {Name} | Ємність: {Capacity} | Кількість: {Quantity}");
        }

    }
}
    
   


