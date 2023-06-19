using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class InverseDiscreteFourierTransform : Algorithm
    {
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }

        public override void Run()
        {
            List<float> Samples = new List<float>();
            List<float> Frequencies = new List<float>();
            List<int> SamplesIndices = new List<int>();




            OutputTimeDomainSignal = new Signal(Samples, SamplesIndices, false, Frequencies, InputFreqDomainSignal.FrequenciesAmplitudes, InputFreqDomainSignal.FrequenciesPhaseShifts);

            for (int i = 0; i < InputFreqDomainSignal.Frequencies.Count; i++)
            {
                double total = 0, koko = 0 , real = 0, imaginary = 0;
                for (int j = 0; j < InputFreqDomainSignal.FrequenciesAmplitudes.Count; j++)
                {
                    real=InputFreqDomainSignal.FrequenciesAmplitudes[j] * Math.Cos(InputFreqDomainSignal.FrequenciesPhaseShifts[j]);
                    imaginary =InputFreqDomainSignal.FrequenciesAmplitudes[j] * Math.Sin(InputFreqDomainSignal.FrequenciesPhaseShifts[j]); 

                    total += real * ((float)Math.Cos((i * 2 * 180 * j / InputFreqDomainSignal.FrequenciesAmplitudes.Count * Math.PI) / 180));
                    koko += -1 * imaginary * ((float)Math.Sin((i * 2 * 180 * j / InputFreqDomainSignal.FrequenciesAmplitudes.Count * Math.PI) / 180));

                }
                OutputTimeDomainSignal.Samples.Add((float)((total+koko) / InputFreqDomainSignal.FrequenciesAmplitudes.Count));
                 OutputTimeDomainSignal.SamplesIndices.Add(i);
            }

            
        }

    }
}

