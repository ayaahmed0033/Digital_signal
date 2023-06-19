using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;


namespace DSPAlgorithms.Algorithms
{
    public class AccumulationSum : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float> sample = new List<float>();
            float sum = 0;

            for (int i = 0; i < InputSignal.Samples.Count ; i++)
            {

                sum += InputSignal.Samples[i];
                sample.Add(sum );
            }
            OutputSignal = new Signal(sample, InputSignal.SamplesIndices, false);
        }
    }
}
