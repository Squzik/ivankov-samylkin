using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using NLog;


namespace DZ
{



    class Program
    {


        static void Main(string[] args)
        {
        
            Console.WriteLine("введите n:");
            int n = int.Parse(Console.ReadLine());
            Log("n = "+ n);
            int mk3 = 0, mk11 = 0, mk33 = 0, max = 0, mpr;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    
                    Console.WriteLine($"введите x:");
                    int x = int.Parse(Console.ReadLine());
                    Log("x = " + x + "\n");

                    if (x % 3 == 0 && x % 11 != 0 && x > mk3)
                        mk3 = x;
                    Log("mk3 = " + mk3 + "\n");
                    if (x % 11 == 0 && x % 3 != 0 && x > mk11)
                        mk11 = x;
                    Log("mk11 = " + mk11 + "\n");
                    if (x % 33 == 0 && x > mk33)
                    {
                        if (mk33 > max)
                            max = mk33;
                        mk33 = x;
                        Log("max = " + max + "\n");
                        Log("mk33 = " + mk33 + "\n");
                    }
                    else if (x > max) max = x;
                    Console.WriteLine($"введите res:");
                    int res = int.Parse(Console.ReadLine());
                    if (mk33 * max > mk3 * mk11)
                    {
                        Console.WriteLine($"Вычисленное контрольное значение:{mk33 * max}");
                        mpr = mk33 * max;
                        Log("mpr = " + mpr + "\n");
                    }
                    else
                    {
                        Console.WriteLine($"Вычисленное контрольное значение:{mk3 * mk11}");
                        mpr = mk3 * mk11;
                        Log("mpr = " + mpr + "\n");
                    }
                    if (res == mpr)
                        Console.WriteLine("Контроль пройден");
                    else
                        Console.WriteLine("Контролько не пройден");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");

            }
        }
        public static void Log(string message)
        {
            try
            {
                File.AppendAllText("D:\\log.txt", message);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
        }

    }
}

