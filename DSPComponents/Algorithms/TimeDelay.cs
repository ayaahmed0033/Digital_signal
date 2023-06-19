using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class TimeDelay : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public float InputSamplingPeriod { get; set; }
        public float OutputTimeDelay { get; set; }

        public override void Run()
        {
            DirectCorrelation direct= new DirectCorrelation();
            List <float> sample = new List<float>();
           for (int i = 0; i < InputSignal1.Samples.Count; i++)
            {
                sample.Add(direct.OutputNonNormalizedCorrelation[i]);
            }
            float max_value = Math.Abs(sample.Max());
            float min_value = Math.Abs(sample.Min());

            OutputTimeDelay = sample.IndexOf(max_value) * InputSamplingPeriod;

        }
    }
}
