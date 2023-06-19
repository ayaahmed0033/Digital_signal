using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{

    public class Sampling : Algorithm
    {

        public int L { get; set; } //upsampling factor
        public int M { get; set; } //downsampling factor
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }


        List<float> yala = new List<float>();
        List<float> output_after_fir = new List<float>();


        public override void Run()
        {

            FIR fir_object = new FIR();
            fir_object.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.LOW;
            fir_object.InputFS = 8000;
            fir_object.InputStopBandAttenuation = 50;
            fir_object.InputCutOffFrequency = 1500;
            fir_object.InputTransitionBand = 500;


            if (M == 0 && L != 0) //upsample  
            {    //upsample el awl then n3ml fir 
                upsample();
                fir_object.InputTimeDomainSignal = new Signal(yala, false);
                fir_object.Run();
                output_after_fir = fir_object.OutputYn.Samples;
                OutputSignal = new Signal(output_after_fir, false);


            }
            else if (M != 0 && L == 0) //downsampling 
            {   /// fir first then down sample
                fir_object.InputTimeDomainSignal = new Signal(InputSignal.Samples, false);
                fir_object.Run();
                output_after_fir = fir_object.OutputYn.Samples;
                DownSample();
                OutputSignal = new Signal(yala, false);
            }

            else if (L != 0 && M != 0)
            {

                upsample();
                fir_object.InputTimeDomainSignal = new Signal(yala, false);
                fir_object.Run();
                output_after_fir = fir_object.OutputYn.Samples;
                yala.Clear();
                DownSample();
                OutputSignal = new Signal(yala, false);

            }
            else if (L == 0 && M == 0)
            {
                throw new Exception("both values are 0");

            }



        }

        void upsample()
        {
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                yala.Add(InputSignal.Samples[i]);
                /// NEEDED 3shan keda hay7ot zereos b3d a5er point :-(
                if (i != InputSignal.Samples.Count - 1)
                {
                    for (int j = 0; j < L - 1; j++)
                    {
                        yala.Add(0);
                    }
                }

            }


        }
        void DownSample()
        {    //beya5od points kol M
            for (int i = 0; i < output_after_fir.Count(); i += M)
            {
                yala.Add(output_after_fir[i]);
            }



        }
    }

}