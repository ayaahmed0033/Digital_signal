using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }
        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            int size = InputSignal2.Samples.Count + InputSignal1.Samples.Count - 1;
            List<float> samples = new List<float>();
            List<int> indexes = new List<int>();




            int start1 = InputSignal1.SamplesIndices[0];
            int start2 = InputSignal2.SamplesIndices[0];
            int n = start1 + start2;
            for (int i = 0; i < size; i++)
            {
                float sample = 0;
                for (int l = 0; l < InputSignal1.Samples.Count; l++)
                {
                    if ((i - l) < InputSignal2.Samples.Count && (i - l) >= 0)
                    {
                        sample += (InputSignal1.Samples[l] * InputSignal2.Samples[i - l]);
                    }
                }
                samples.Add(sample);
                indexes.Add(n);
                n++;
            }


            if (samples[0] == 0)
            {
                samples.RemoveAt(0);
                indexes.RemoveAt(0);

            }
            else if (samples[samples.Count - 1] == 0)
            {
                samples.RemoveAt(samples.Count - 1);
                indexes.RemoveAt(indexes.Count - 1);

            }
            OutputConvolvedSignal = new Signal(samples, indexes, false);

        }
    }
}
