
using System;
using static System.Console;
using System.Text;


public class Main_Class
{
    public static void Main()
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            

            int answer;
            Console.WriteLine();

            do
            {
                WriteLine("1 - : ");
                WriteLine("2 - : ");
                WriteLine("3 - : ");
                WriteLine("4. ");
                WriteLine("5." );
                WriteLine("6. ");
                WriteLine("7. ");
                WriteLine("8. ");
                WriteLine("9. ");
                WriteLine("10 - ");
                WriteLine("0 - Exit: ");

                answer = int.Parse(ReadLine());


                switch (answer)
                {
                    case 1:
                        {
                            
                            break;
                        }

                    case 2:
                        {
                            
                        }
                    case 3:
                        {
                           
                        }
                    case 4:
                        {
                            
                        }

                    case 5:
                        {
                            
                        }

                    case 6:
                        {
                            
                        }

                    case 7:
                        {
                            
                        }

                    case 8:
                        {
                            
                        }

                    case 9:
                        {
                            
                        }

                    case 10:
                        {
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



