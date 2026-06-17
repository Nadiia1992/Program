using InterfaceLibrary;
using System;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using PriceListt; 


namespace SerializationLibrary
{
    public class XMLSerialize : ISerialize
    {
        public void Save(string filePath, object obj)
        {
            PriceList priceList = (PriceList)obj;

            XmlSerializer serializer = new XmlSerializer(typeof(PriceList));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, priceList);
            }
        }

        public object Load(string filePath)
        {
            if (!File.Exists(filePath)) return null;

            XmlSerializer serializer = new XmlSerializer(typeof(PriceList));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (PriceList)serializer.Deserialize(fs);
            }
        }
    }
}
