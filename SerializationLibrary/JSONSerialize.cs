using ClassLibrary;
using InterfaceLibrary;
using PriceListt;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SerializationLibrary
{
    public class JSONSerialize : ISerialize
    {
        public void Save(string filePath, object obj)
        {

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PriceList));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.WriteObject(fs, obj);
            }
        }

        public object Load(string filePath)
        {
            if (!File.Exists(filePath)) return new List<Storage>();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PriceList));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (PriceList)serializer.ReadObject(fs);
            }
        }
    }
}