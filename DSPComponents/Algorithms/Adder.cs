using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Adder : Algorithm
    {
        public List<Signal> InputSignals { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float> sample = new List<float>();
                for (int j = 0; j < InputSignals[0].Samples.Count; j++)
                {
                sample.Add(InputSignals[0].Samples[j]+ InputSignals[1].Samples[j]);
                }
            OutputSignal = new Signal(sample, false);
        }
    }
}