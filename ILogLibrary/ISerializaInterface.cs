using System;


namespace InterfaceLibrary
{
    public interface ISerialize
    {
        void Save(string filePath, object obj);

        object Load(string filePath);
    }
}
