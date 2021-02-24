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
            int x;

            using (var sim = new QuantumSimulator())
            {
                x = Convert.ToInt32(SampleRandomNumber.Run(sim, 4).Result.ToString());
            }
            // Print the result
            Console.WriteLine($"The random number generated is {x}.");
        }
    }
}
