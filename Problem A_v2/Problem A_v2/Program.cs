using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_A_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int antal;
            decimal sum_clock = 0;
            decimal sum_minutes = 0;
            bool error = false;

            input = Console.ReadLine();
            antal = Convert.ToInt32(input);

            for (int i = 1; i <= antal; i++)
            {
                input = Console.ReadLine();

                string[] split = input.Split(new char[] { ' ' }, StringSplitOptions.None);
                decimal a = Int16.Parse(split[0]);
                decimal b = Int16.Parse(split[1]);

                sum_minutes = sum_minutes + Convert.ToInt32(a);

                decimal sec = (b / 60);

                if (a > sec)
                {
                    Console.WriteLine("measurement error");
                    error = true;
                    break;
                }

                sum_clock = sum_clock + sec;

            }

            if (error == false)
            {
                decimal result = (sum_clock / sum_minutes);
                result = Math.Round(result, 9);
                string output = result.ToString().Replace(",", ".");
                Console.WriteLine(output);
            }
        }
    }
}
