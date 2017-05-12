using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace algorithm_1
{
    class Program
    {
        static double[] ReadData(string path)
        {
            var s = File.ReadAllLines(path, Encoding.Default);

            return s.Select(x => double.Parse(x)).ToArray();
        }


        static void Main(string[] args)
        {
            var input = ReadData("data.txt");
            Console.WriteLine("Input Data:");
            Console.WriteLine("");

            //foreach (var item in input)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("");

            Array.Sort(input);

            var outputUnique = input.Distinct().ToArray();
            var outputRepeating = input.Where(str => input.Count(s => s == str) > 1).ToArray();
            var output_repeating_buffer = outputRepeating.ToList();
            var output_unique_buffer = outputUnique.ToList();
            foreach (var item in outputUnique)
            {
                for (int i = 0; i < output_repeating_buffer.Count; i++)
                {
                    if (item == output_repeating_buffer[i])
                    {
                        output_repeating_buffer.RemoveAt(i);
                        // output_unique_buffer.Remove(item);
                        break;
                    }
                }

            }

            var output = output_repeating_buffer.Concat(outputUnique).ToList();

            var sister = output;
            var brother = new List<double>();
            for (int i = 0; i < output.Count / 2; i++)
            {
                brother.Add(sister[i]);

            }
            sister.RemoveRange(0, output.Count / 2);

            Console.WriteLine("Converted array:");
            Console.WriteLine();

            //foreach (var item in output)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine();

            Console.WriteLine("Answer:");
            Console.WriteLine("Sister`s item array:");
            //foreach (var item in sister)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ForegroundColor = ConsoleColor.Green;
           

            if (outputUnique.Length <= output_repeating_buffer.Count())

                Console.WriteLine("Sister has " + outputUnique.Length + " unique items");
            else
                Console.WriteLine("Sister has " + outputUnique.Length + " unique items");

            Console.ReadKey();
        }
    }
}
