using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace DSPAlgorithms.Algorithms
{
    public class FIR : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public FILTER_TYPES InputFilterType { get; set; }
        public float InputFS { get; set; }
        public float? InputCutOffFrequency { get; set; }
        public float? InputF1 { get; set; }
        public float? InputF2 { get; set; }
        public float InputStopBandAttenuation { get; set; }
        public float InputTransitionBand { get; set; }
        public Signal OutputHn { get; set; }
        public Signal OutputYn { get; set; }
        int N = 0;
        float wc = 0, wc1 = 0, wc2 = 0, index = 0, h = 0, w = 0;


        public override void Run()
        {

            float Delta_F = InputTransitionBand / InputFS;
            OutputHn = new Signal(new List<float>(), new List<int>(), false);
            //  List<float> sample_of_hn = new List<float>();
            float smearing = 0;
            float smearingf1 = 0;
            float smearingf2 = 0;

            /////////////////////////////////////////////////////////////////////////////////////////
            ///
            float Choose_function(int index)
            {

                if (InputStopBandAttenuation <= 21)
                {

                    w = Rectangular(index);
                }
                else if (InputStopBandAttenuation > 21 && InputStopBandAttenuation <= 44)
                {

                    w = Hanning(index);
                }
                else if (InputStopBandAttenuation > 44 && InputStopBandAttenuation <= 53)
                {
                    w = Hamming(index);

                }
                else if (InputStopBandAttenuation > 53 && InputStopBandAttenuation <= 74)
                {
                    w = Blackman(index);


                }


                return w;
            }
            //low pass Filter
            if (InputFilterType == FILTER_TYPES.LOW)
            {
                if (InputStopBandAttenuation <= 21)
                {
                    N = (int)Math.Floor(0.9 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }
                }
                else if (InputStopBandAttenuation > 21 && InputStopBandAttenuation <= 44)
                {
                    N = (int)Math.Floor(3.1 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }

                }
                else if (InputStopBandAttenuation > 44 && InputStopBandAttenuation <= 53)
                {

                    N = (int)Math.Floor(3.3 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }
                }
                else if (InputStopBandAttenuation > 53 && InputStopBandAttenuation <= 74)
                {

                    N = (int)Math.Floor(5.5 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }

                }
                for (int i = 0, n = (int)-N / 2; i < N; i++, n++)
                {
                    OutputHn.SamplesIndices.Add(n);
                }

                //smearing effect
                smearing = (float)((InputCutOffFrequency + (InputTransitionBand / 2)) / InputFS);

                for (int i = 0; i < N; i++)
                {
                    index = Math.Abs(OutputHn.SamplesIndices[i]);
                    if (OutputHn.SamplesIndices[i] == 0)
                    {
                        h = (float)(2 * smearing);
                    }
                    else
                    {
                        wc = (float)(2 * Math.PI * smearing * index);
                        h = (float)(2 * smearing * Math.Sin(wc) / wc);

                    }
                    w = Choose_function((int)index);
                    OutputHn.Samples.Add(h * w);
                }

            }
            /////////////////////////////////////////////////////////////////////////////////
            //High pass filter 
            else if (InputFilterType == FILTER_TYPES.HIGH)
            {
                if (InputStopBandAttenuation <= 21)
                {
                    N = (int)Math.Floor(0.9 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }
                }
                else if (InputStopBandAttenuation > 21 && InputStopBandAttenuation <= 44)
                {
                    N = (int)Math.Floor(3.1 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }

                }
                else if (InputStopBandAttenuation > 44 && InputStopBandAttenuation <= 53)
                {

                    N = (int)Math.Floor(3.3 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }
                }
                else if (InputStopBandAttenuation > 53 && InputStopBandAttenuation <= 74)
                {

                    N = (int)Math.Floor(5.5 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }

                }
                for (int i = 0, n = (int)-N / 2; i < N; i++, n++)
                {
                    OutputHn.SamplesIndices.Add(n);
                }
                //smearing effect
                smearing = (float)((InputCutOffFrequency + (InputTransitionBand / 2)) / InputFS);
                for (int i = 0; i < N; i++)
                {
                    index = Math.Abs(OutputHn.SamplesIndices[i]);
                    if (OutputHn.SamplesIndices[i] == 0)
                    {
                        h = (float)(1 - (2 * smearing));

                    }
                    else
                    {

                        wc = (float)(2 * Math.PI * smearing * index);
                        h = (float)(-2 * smearing * Math.Sin(wc) / wc);

                    }
                    w = Choose_function((int)index);
                    OutputHn.Samples.Add(h * w);
                }

            }
            ///////////////////////////////////////////////////////////////////////////////////
            //Band pass
            else if (InputFilterType == FILTER_TYPES.BAND_PASS)
            {
                if (InputStopBandAttenuation <= 21)
                {
                    N = (int)Math.Floor(0.9 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }
                }
                else if (InputStopBandAttenuation > 21 && InputStopBandAttenuation <= 44)
                {
                    N = (int)Math.Floor(3.1 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }

                }
                else if (InputStopBandAttenuation > 44 && InputStopBandAttenuation <= 53)
                {

                    N = (int)Math.Floor(3.3 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }
                }
                else if (InputStopBandAttenuation > 53 && InputStopBandAttenuation <= 74)
                {

                    N = (int)Math.Floor(5.5 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }

                }
                for (int i = 0, n = (int)-N / 2; i < N; i++, n++)
                {
                    OutputHn.SamplesIndices.Add(n);
                }
                //smearing effect
                smearingf1 = (float)((InputF1 - (InputTransitionBand / 2)) / InputFS);
                smearingf2 = (float)((InputF2 + (InputTransitionBand / 2)) / InputFS);

                for (int i = 0; i < N; i++)
                {
                    index = Math.Abs(OutputHn.SamplesIndices[i]);
                    if (OutputHn.SamplesIndices[i] == 0)
                    {
                        h = (float)(2 * (smearingf2 - smearingf1));
                    }
                    else
                    {

                        wc2 = (float)(2 * Math.PI * smearingf2 * index);
                        wc1 = (float)(2 * Math.PI * smearingf1 * index);
                        h = (float)((2 * smearingf2 * Math.Sin(wc2) / wc2) - (2 * smearingf1 * Math.Sin(wc1) / wc1));

                    }
                    w = Choose_function((int)index);
                    OutputHn.Samples.Add(h * w);

                }

            }


            ///////////////////////////////////////////////////////////////////////////////////
            //Band Stop
            else if (InputFilterType == FILTER_TYPES.BAND_STOP)
            {
                if (InputStopBandAttenuation <= 21)
                {
                    N = (int)Math.Floor(0.9 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }
                }
                else if (InputStopBandAttenuation > 21 && InputStopBandAttenuation <= 44)
                {
                    N = (int)Math.Floor(3.1 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }

                }
                else if (InputStopBandAttenuation > 44 && InputStopBandAttenuation <= 53)
                {

                    N = (int)Math.Floor(3.3 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }
                }
                else if (InputStopBandAttenuation > 53 && InputStopBandAttenuation <= 74)
                {

                    N = (int)Math.Floor(5.5 / Delta_F);
                    if (N % 2 == 1)
                    {
                        N += 2;
                    }
                    else
                    {
                        N++;
                    }

                }
                for (int i = 0, n = (int)-N / 2; i < N; i++, n++)
                {
                    OutputHn.SamplesIndices.Add(n);
                }
                //smearing effect
                smearingf1 = (float)((InputF1 - (InputTransitionBand / 2)) / InputFS);
                smearingf2 = (float)((InputF2 + (InputTransitionBand / 2)) / InputFS);

                for (int i = 0; i < N; i++)
                {
                    index = Math.Abs(OutputHn.SamplesIndices[i]);
                    if (OutputHn.SamplesIndices[i] == 0)
                    {
                        h = (float)(1 - (2 * (smearingf2 - smearingf1)));
                    }
                    else
                    {

                        wc1 = (float)(2 * Math.PI * smearingf1 * index);
                        wc2 = (float)(2 * Math.PI * smearingf2 * index);
                        h = (float)((2 * smearingf1 * Math.Sin(wc1) / wc1) - (2 * smearingf2 * Math.Sin(wc2) / wc2));

                    }
                    w = Choose_function((int)index);
                    OutputHn.Samples.Add(h * w);
                }

            }

            ///////////////////////////////////////////////////////////////////////////////////
            ///Functions for W



            /////Rectangular 
            float Rectangular(int index)
            {

                return 1;

            }
            ///Hanning 
            float Hanning(int index)
            {
                // DELTA F =transition width / sampling frequency. ----> N= num /delta f
                w = (float)0.5 + (float)(0.5 * Math.Cos((2 * Math.PI * index) / N));
                return w;
            }

            ///Hamming 
            float Hamming(int index)
            {

                // DELTA F =transition width / sampling frequency. ----> N= num /delta f 
                w = (float)0.54 + (float)(0.46 * Math.Cos((2 * Math.PI * index) / N));
                return w;

            }
            ///Blackman 
            float Blackman(int index)
            {
                // DELTA F =transition width / sampling frequency. ----> N= num /delta f
                float term1 = (float)(0.5 * Math.Cos((2 * Math.PI * index) / (N - 1)));
                float term2 = (float)(0.08 * Math.Cos((4 * Math.PI * index) / (N - 1)));
                w = (float)(0.42 + term1 + term2);
                return w;

            }

            DirectConvolution Dc = new DirectConvolution();
            Dc.InputSignal1 = InputTimeDomainSignal;
            Dc.InputSignal2 = OutputHn;
            Dc.Run();
            OutputYn = Dc.OutputConvolvedSignal;

        }


    }
}