
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Soap;
using ClassLibrary;
using InterfaceLibrary;
using PriceListt;

namespace SerializationLibrary
{
    public class SoapSerialize : ISerialize
    {
        public void Save(string filePath, object obj)
        {
            PriceList priceList = (PriceList)obj;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(fs, priceList);
            }
        }

       
        public object Load(string filePath)
        {
            if (!File.Exists(filePath)) return null;

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                SoapFormatter formatter = new SoapFormatter();
                return (PriceList)formatter.Deserialize(fs);
            }
        }
    }
}
