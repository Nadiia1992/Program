using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    public abstract class Storage
    {
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


        public Storage()
        {
            NameManufacturer = "nameM";
            Model = "Model";
            NameManufacturer = "name";
            Capacity = 0;
            Quantity = 0;

        }
        public virtual void Print()
        {
            Console.WriteLine("Назва виробника: {0}  Модель: {1}  Наіменування: {2} Ємність: {3} Кількість : {4}"
                , NameManufacturer, Model, Name, Quantity, Capacity);
        }
        public virtual void Save() { }
        public virtual void Load() { }
    }

    [Serializable]
    [DataContract]
    public class Flash : Storage
    {
        [DataMember]
        public int SpeedUSB { get; set; }

        public Flash() : base()
        {
            SpeedUSB = 0;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Швидкість USB: {0}", SpeedUSB);
        }

        public override void Save() { }
        public override void Load() { }
    }

    [Serializable]
    [DataContract]
    public class DVD : Storage
    {
        [DataMember]
        public string WriteSpeed { get; set; }

        public DVD() : base()
        {
            WriteSpeed = "0x";
           
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Швидкість читання: {0}" , WriteSpeed);
        }

        public override void Save() { }
        public override void Load() { }
    }

    [Serializable]
    [DataContract]
    public class HDD : Storage
    {
        [DataMember]
        public int SpeedHDD { get; set; }

        public HDD() : base()
        {
            
            SpeedHDD = 0;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Тип: {0}  Ємність HDD: {1}  Швидкість роботи: {2}",SpeedHDD);
        }

        public override void Save() { }
        public override void Load() { }
    }
}
}
