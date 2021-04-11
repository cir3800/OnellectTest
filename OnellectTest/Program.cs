using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Net.Http;

namespace OnellectTest
{
    class Program
    {
        public object ConfigurationManager { get; private set; }

        static int[] generateMas()
        {
            int sizeMas;
            int[] mas;
            Random rand = new Random(DateTime.UtcNow.Millisecond);
            sizeMas = rand.Next(20, 100);
            mas = new int[sizeMas];
            for (int i = 0; i < sizeMas; i++)
                mas[i] = rand.Next(-100, 100);
            return mas;
        }

        static void showMas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
                Console.Write(mas[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
        }

        static int[] sortBubble(int[] mas)
        {
            for(int i = 0; i < mas.Length - 1; i++)
                for(int j = i + 1; j < mas.Length; j++)
                {
                    if(mas[i] > mas[j])
                    {
                        mas[i] = mas[i] + mas[j];
                        mas[j] = mas[i] - mas[j];
                        mas[i] = mas[i] - mas[j];
                    }
                }
            return mas;
        }

        static int[] sortInsert(int[] mas)
        {
            for (int i = 1; i < mas.Length; i++)
                for (int j = i; j > 0 && mas[j - 1] > mas[j]; j--)
                {
                    mas[j - 1] = mas[j - 1] + mas[j];
                    mas[j] = mas[j - 1] - mas[j];
                    mas[j - 1] = mas[j - 1] - mas[j];
                }
            return mas;
        }

            static void startSort(int[] mas)
        {
            string[] listSorts = { "sortBubble", "sortInsert" };
            Random rand = new Random(DateTime.UtcNow.Millisecond);

            int rnd = rand.Next(listSorts.Length);
            if (rnd == 0)
            {
                Console.WriteLine(listSorts[0]);
                sortBubble(mas);
            }
            else
            {
                Console.WriteLine(listSorts[1]);
                sortInsert(mas);
            }
        }

        static void Main(string[] args)
        {
            int[] massiv = generateMas();
            string finishAddress = "";
            // int[] m = massiv;
            showMas(massiv);
            startSort(massiv);
            /*showMas(sortBubble(massiv));
            Console.WriteLine();
            showMas(sortInsert(m));
            Console.WriteLine();*/
            showMas(massiv);
            var appSettings = ConfigurationSettings.AppSettings;
            finishAddress = appSettings["finishAddress"];
        }
    }
}
