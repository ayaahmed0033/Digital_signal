using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Normalizer : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputMinRange { get; set; }
        public float InputMaxRange { get; set; }
        public Signal OutputNormalizedSignal { get; set; }

        public override void Run()
        {float max = InputSignal.Samples.Max();
            float min = InputSignal.Samples.Min();

            List<float> sample = new List<float>();
           
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                sample.Add((InputMaxRange- InputMinRange) * (( InputSignal.Samples[i] - min) / (max - min))+ InputMinRange);
            }
            OutputNormalizedSignal = new Signal(sample, false);
        }//zi = (xi – min(x)) / (max(x) – min(x))
    }
}
