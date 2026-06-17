
using ClassLibrary;
using ClassLog;
using InterfaceLibrary;
using PriceListt;
using SerializationLibrary;
using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Console;


public class Main_Class
{
    public static void Main()
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            PriceList devices = new PriceList();
            ILog logger = new ConsoleLog();

            devices.Add(new Flash
            {
                Type = "Flash",
                NameManufacturer = "Kingston",
                Model = "DT100",
                Name = "USB 1",
                Capacity = 64,
                Quantity = 1,
                SpeedUSB = 300
            });


            devices.Add(new Flash
            {
                Type = "Flash",
                NameManufacturer = "SanDisk",
                Model = "Ultra",
                Name = "USB 2",
                Capacity = 128,
                Quantity = 2,
                SpeedUSB = 400
            });

            devices.Add(new DVD
            {
                Type = "DVD",
                NameManufacturer = "Verbatim",
                Model = "DVD-R",
                Name = "Blank DVD Disc",
                Capacity = 4,
                Quantity = 10,
                WriteSpeed = 16
            });


            devices.Add(new HDD
            {
                Type = "HDD",
                NameManufacturer = "Seagate",
                Model = "Barracuda",
                Name = "Hard Drive",
                Capacity = 1024,
                Quantity = 1,
                SpeedHDD = 7200
            });
            int answer;
            Console.WriteLine();

            do
            {
                WriteLine("1 - Друк списку. ");
                WriteLine("2 - Додати носія інформації до списку. ");
                WriteLine("3 - Видалити носія інформації зі списку за ім'ям. ");
                WriteLine("4 - Редагувати кількість носія інформації. ");
                WriteLine("5 - Пошук носія інформації за ім'ям. ");
                WriteLine("6 - Запис даних у файл формату SOAP. ");
                WriteLine("7 - Запис даних у файл формату XML. ");
                WriteLine("8 - Запис даних у файл формату JSON. ");
                WriteLine("9 - Зчитування даних із файлу SOAP.");
                WriteLine("10 - Зчитування даних із файлу XML.");
                WriteLine("11 - Зчитування даних із файлу JSON.");
                WriteLine("0 - Exit: ");

                answer = int.Parse(ReadLine());


                switch (answer)
                {
                    case 1:
                        {
                            WriteLine("\n----Список носіїв: ");
                            devices.PrintAll(logger);
                            break;
                        }

                    case 2:
                        {
                            Write("\nВиберіть тип: ");
                            Write("1 - Flash: ");
                            Write("2 - DVD: ");
                            Write("3 - HDD: ");

                            int type = int.Parse(ReadLine());

                            Write("Виробник: ");
                            string manufacturer = ReadLine();

                            Write("Модель: ");
                            string model = ReadLine();

                            Write("Назва: ");
                            string name = ReadLine();

                            Write("Ємність: ");
                            int capacity = int.Parse(ReadLine());

                            Write("Кількість:");
                            int quantity = int.Parse(ReadLine());

                            if (type == 1)
                            {
                                Write("USB швидкість: ");
                                int speed = int.Parse(ReadLine());
                                devices.Add(new Flash(manufacturer, model, name, capacity, quantity, speed));

                            }

                            else if (type == 2)
                            {
                                Write("Швидкість запису DVD: ");
                                int writespeed = int.Parse(ReadLine());
                                devices.Add(new DVD(manufacturer, model, name, capacity, quantity, writespeed));
                            }

                            else if (type == 3)
                            {
                                Write("Швидкість шпинделя HDD: ");
                                int speedhdd = int.Parse(ReadLine());
                                devices.Add(new HDD(manufacturer, model, name, capacity, quantity, speedhdd));
                            }
                            WriteLine("Носій успішно доданий!");
                            break;
                        }

                    case 3:
                        {
                            Write("\nВведіть Назву носія для видалення: ");
                            string toRemove = ReadLine();
                            devices.RemoveByName(toRemove);
                            break;
                        }
                    case 4:
                        {
                            Write("Введіть Назву носія для зміни кількості: ");
                            string ToEdit = ReadLine();
                            Write("Введіть нову кількість: ");
                            int newQty = int.Parse(ReadLine());

                            devices.EditQuantityByName(ToEdit, newQty);
                            break;
                        }

                    case 5:
                        {
                            Write("Введіть Назву носія для пошуку: ");
                            string toFind = ReadLine();

                            devices.FindByName(toFind, logger);
                            break;
                        }

                    case 6:
                        {
                            devices.SaveToFile("devices.soap", new SoapSerialize());
                            WriteLine("Дані збережено в SOAP.");
                            break;
                        }

                    case 7:
                        {
                            devices.SaveToFile("devices.xml", new XMLSerialize());
                            WriteLine("Дані збережено в XML.");
                            break;
                        }

                    case 8:
                        {
                            devices.SaveToFile("devices.json", new JSONSerialize());
                            WriteLine("Дані збережено в JSON.");
                            break;
                        }

                    case 9:
                        {
                            devices.LoadFromFile("devices.soap", new SoapSerialize());
                            WriteLine("Дані завантажено з SOAP.");
                            devices.PrintAll(logger);

                            break;
                        }

                    case 10:
                        {
                            devices.LoadFromFile("devices.xml", new XMLSerialize());
                            WriteLine("Дані завантажено з XML.");
                            devices.PrintAll(logger);

                            break;
                        }

                    case 11:
                        {
                            devices.LoadFromFile("devices.json", new JSONSerialize());
                            WriteLine("Дані завантажено з JSON.");
                            devices.PrintAll(logger);

                            break;
                        }
                }
            } while (answer != 0);

        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
        }
    }
}



