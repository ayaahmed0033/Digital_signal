using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }
        public override void Run()
        {

            ////////////////////////////////////////////
            List<double> sinat = new List<double>();   //aka sin
            for (int i = 0; i < InputTimeDomainSignal.Samples.Count; i++)
            {
                sinat.Add(0.0f);
            }
            List<double> cosinat = new List<double>();
            for (int i = 0; i < InputTimeDomainSignal.Samples.Count; i++)
            {
                cosinat.Add(0.0f);
            }
            ////////////////////////////////////////////
            float omga = (2.0f * (float)Math.PI) / (InputTimeDomainSignal.Samples.Count * (1.0f / InputSamplingFrequency));
            Signal sample = new Signal(new List<float>(), false);
            ////////////////////////////////////////////
            sample.FrequenciesAmplitudes = new List<float>();

            sample.FrequenciesPhaseShifts = new List<float>();
            ////////////////////////////////////////////
            for (int i = 0; i < InputTimeDomainSignal.Samples.Count; i++)
            {

                //sample.FrequenciesAmplitudes = new List<float>();

                //sample.FrequenciesPhaseShifts = new List<float>();

                for (int j = 0; j < InputTimeDomainSignal.Samples.Count; j++)
                {
                    float value = (-2.0f * j * (float)Math.PI * i) / InputTimeDomainSignal.Samples.Count;

                    cosinat[i] += InputTimeDomainSignal.Samples[j] * Math.Cos(value);
                    sinat[i] += InputTimeDomainSignal.Samples[j] * Math.Sin(value);

                }


                sample.FrequenciesAmplitudes.Add((float)Math.Sqrt(cosinat[i] * cosinat[i] + sinat[i] * sinat[i]));

                sample.FrequenciesPhaseShifts.Add((float)Math.Atan2(sinat[i], cosinat[i]));


            }
            OutputFreqDomainSignal = new Signal(false, new List<float>(), sample.FrequenciesAmplitudes, sample.FrequenciesPhaseShifts);
        }
    }
}
