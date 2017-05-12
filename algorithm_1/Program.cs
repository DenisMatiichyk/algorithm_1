using System;
using System.Collections;
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
            var outputRepeating = input.Where(str =>
            {
                int count = 0;
                foreach (var s in input)
                {
                    if (s == str) count++;
                }
                return count > 1;
            });
            var output_repeating_buffer = outputRepeating.ToList();
            // var output_unique_buffer = outputUnique.ToList();
            foreach (var item in outputUnique)
            {
                // output_repeating_buffer =output_repeating_buffer.Except(outputUnique);
                output_repeating_buffer.Remove(item);
                //for (var i = 0; i < output_repeating_buffer.Count; i++)
                //{
                //    if (item == output_repeating_buffer[i])
                //    {
                //        output_repeating_buffer.RemoveAt(i);
                //        break;
                //    }
                //}

            }

            var output = output_repeating_buffer.Concat(outputUnique).ToList();


            var chunkLength = output.Count() / 2;
            var cLength = output.Count();
            var brother = Enumerable.Range(0, chunkLength)
                .Select(i => output.Skip(i * chunkLength).Take(chunkLength)).ToArray();
           
             output.RemoveRange(0,chunkLength);
            var sister = output;
            //Enumerable.Range(chunkLength, cLength)
            // .Select(i => output.Skip(i * cLength).Take(cLength).ToArray());

            // sister = output.(brother);
            //  brother.CopyTo(sister, brother.Length/2);

            //Array.Copy(sister, brother, (output.Count() / 2));

            //Array.Clear(sister,0, output.Count() / 2);
            //Console.WriteLine("Converted array:");
            //Console.WriteLine();

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
                Console.WriteLine("Sister has " + sister.Count() + " unique items");

            // Console.ReadKey();
        }
    }
}
