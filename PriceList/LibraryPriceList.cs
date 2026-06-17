using ClassLibrary;
using InterfaceLibrary;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PriceListt
{
    [Serializable]
    [DataContract]
    public class PriceList
    {
        [DataMember]
        public List<Storage> Items { get; set; }

        public PriceList()
        {
            Items = new List<Storage>();
        }

        public void Add(Storage item)
        {
            Items.Add(item);
        }

        public void RemoveByName(string name)
        {
            Storage found = null;
            foreach (Storage item in Items)
            {
                if (item.Name == name)
                {
                    found = item;
                    break;
                }
            }
            if (found != null)
            {
                Items.Remove(found);
                Console.WriteLine("Носій успішно видалено зі списку!");
            }
            else
            {
                Console.WriteLine("Носій з такою назвою не знайдено.");
            }
        }

        public void FindByName(string name, ILog logger)
        {
            bool found = false;
            foreach (Storage item in Items)
            {
                if (item.Name == name)
                {
                    item.Print(logger);
                    found = true;
            }
        }
            if (found == false)
            {
                logger.Print("Нічого не знайдено за цією назвою.");

            }
        }

        public void EditQuantityByName(string name, int newQuantity)
        {
            Storage found = null;
            foreach (Storage item in Items)
            {
                if (item.Name == name)
                {
                    found = item;
                    break;
                }
            }
            if (found != null)
            {
                found.Quantity = newQuantity;
                Console.WriteLine("Параметри успішно змінено!");
            }
            else
            {
                Console.WriteLine("Носій з такою назвою не знайдено.");
            }
        }


        public void PrintAll(ILog logger)
        {
            if (Items.Count == 0)
            {
                logger.Print("Список пустий.");
                return;
            }
            foreach (Storage item in Items)
            {
                item.Print(logger);
            }
        }

        public void SaveToFile(string filePath, ISerialize serializer)
        {
            serializer.Save(filePath, this);
        }

        public void LoadFromFile(string filePath, ISerialize serializer)
        {
            PriceList loadedData = serializer.Load(filePath) as PriceList;

            if (loadedData != null)
            {
                this.Items = loadedData.Items;
            }
        }
    }
}


