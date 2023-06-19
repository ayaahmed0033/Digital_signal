using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectCorrelation : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }

        public override void Run()
        {

            List<float> samples = new List<float>();

            //////////////////////////////////////////////////
            for (int i = 0; i < InputSignal1.Samples.Count; i++)
            {
                samples.Add(0.0f);
            }
            if (InputSignal2 == null)// auto corr
            {
                InputSignal2 = new Signal(new List<float>(), InputSignal1.Periodic);
                for (int i = 0; i < InputSignal1.Samples.Count; i++)
                {
                    InputSignal2.Samples.Add(InputSignal1.Samples[i]);
                }
            }
            // added by manar 
            //////////////////////////////////////////////////

            List<float> p = new List<float>();
            float sum1 = 0, sum2 = 0;
            for (int k = 0; k < InputSignal1.Samples.Count; k++)
            {
                sum1 += InputSignal1.Samples[k] * InputSignal1.Samples[k];
                sum2 += InputSignal2.Samples[k] * InputSignal2.Samples[k];
            }
            float value = (float)Math.Sqrt(sum1 * sum2) / InputSignal1.Samples.Count; //dominator
            for (int i = 0; i < InputSignal1.Samples.Count; i++)
            {
                for (int j = 0; j < InputSignal1.Samples.Count; j++)
                {
                    if (InputSignal1.Periodic)
                    {
                        int indexer = (j + i) % InputSignal1.Samples.Count;
                        samples[i] += (InputSignal1.Samples[j] * InputSignal2.Samples[indexer]);
                    } //shifting
                    else if (InputSignal1.Periodic == false) // no shifting we put zeros at the end 
                    {
                        if (i + j >= InputSignal1.Samples.Count)
                        {
                            samples[i] += 0;
                        }
                        else
                        {
                            samples[i] += (InputSignal1.Samples[j] * InputSignal2.Samples[j + i]);
                        }

                    }

                }
                samples[i] /= InputSignal1.Samples.Count;
                p.Add((samples[i] / value));// p[i] = (samples[i] / value); updated by manar

            }
            OutputNonNormalizedCorrelation = samples;
            OutputNormalizedCorrelation = p;

        }

    }
}
