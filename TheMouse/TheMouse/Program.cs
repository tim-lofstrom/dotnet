using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheMouse
{
    class Program
    {
        static void Main(string[] args)
        {

            Mouse mouse;

            int prev = 0;
            int medel = 0;

            for (int j = 3; j < 34; j += 2)
            {
                mouse = null;
                mouse = new Mouse(j);
                double runs = 0;
                double total = 0;

                for (int i = 0; i < 999999; i++)
                {
                    total += mouse.Minutes();
                    runs++;
                }

                medel = Convert.ToInt32(Math.Round(Convert.ToDouble(total) / Convert.ToDouble(runs)));

                Console.WriteLine("Antal burar: " + j + "st - Ger medellivslängden: " + medel + "  Skillnad: " + (medel - prev));

                prev = medel;
            }


            Console.Read();
        }
    }
}
