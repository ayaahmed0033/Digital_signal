using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class FastCorrelation : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }
        double imaginary = 0; int real = 0;
        List<float> real_plus_imaginary = new List<float>();
        public override void Run()
        {
            List<float> output_nonnormalised = new List<float>();
            List<float> output_normalised = new List<float>();
            double sum1 = 0, sum2 = 0, total_dom = 0;
            if (InputSignal1.Samples.Count < InputSignal2.Samples.Count)
            {
                for (int i = 0; i < InputSignal2.Samples.Count - InputSignal1.Samples.Count; i++)
                {
                    InputSignal1.Samples.Add(0);
                }

            }
            else if (InputSignal1.Samples.Count > InputSignal2.Samples.Count)
            {
                for (int i = 0; i < InputSignal1.Samples.Count - InputSignal2.Samples.Count; i++)
                {
                    InputSignal2.Samples.Add(0);
                }

            }
            for (int i = 0; i < InputSignal1.Samples.Count; i++)
            {
                InputSignal1.Samples[i] *= InputSignal2.Samples[i] * InputSignal1.Samples[i];
                real = (int)(InputSignal1.FrequenciesAmplitudes[i] * Math.Cos(InputSignal1.FrequenciesPhaseShifts[i]));
                imaginary = InputSignal1.FrequenciesAmplitudes[i] * Math.Sin(InputSignal1.FrequenciesPhaseShifts[i]);
                imaginary *= -1;
                real_plus_imaginary[i] = (float)(real + imaginary);

                sum1 += Math.Pow(InputSignal1.Samples[i], 2);
                sum2 += Math.Pow(InputSignal2.Samples[i], 2);

            }
            total_dom = (sum1 + sum2) / InputSignal1.Samples.Count;
            InverseDiscreteFourierTransform koko = new InverseDiscreteFourierTransform();
            koko.Run();
            koko.InputFreqDomainSignal = InputSignal1;

            for (int i = 0; i < InputSignal1.Samples.Count; i++)
            {
                koko.OutputTimeDomainSignal.Samples[i] /= InputSignal1.Samples.Count;
                output_nonnormalised[i] = koko.OutputTimeDomainSignal.Samples[i];
                output_normalised[i] = koko.OutputTimeDomainSignal.Samples[i];
            }
            OutputNonNormalizedCorrelation = output_nonnormalised;
            OutputNormalizedCorrelation = output_normalised;

        }
    }
}