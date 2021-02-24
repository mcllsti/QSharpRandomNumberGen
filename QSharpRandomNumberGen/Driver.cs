using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using Quantum.QSharpRandomNumberGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSharpRandomNumberGen
{
    class Driver
    {
        static void Main(string[] args)
        {
            do
            {
                GetRandomNumber();
            } while (!Console.ReadLine().Equals("No"));
        }

        private static void GetRandomNumber()
        {
            int max = GetUserInput();

            using (var sim = new QuantumSimulator())
            {
                int randNum = Convert.ToInt32(SampleRandomNumber.Run(sim, max).Result.ToString());
                Console.WriteLine($"The random number generated is {randNum}.");
                Console.WriteLine($"Run again? Yes/No {Environment.NewLine}");
            }
        }

        private static int GetUserInput()
        {
            Console.WriteLine("Please enter a maximum threshold:");
            string input = Console.ReadLine();
            int max;

            if (!int.TryParse(input, out max))
            {
                Console.WriteLine("Input is not valid, proceeding with default value 50.");
                max = 50;
            };

            return max;
        }
    }
}
