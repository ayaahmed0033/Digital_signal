using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Shifter : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int ShiftingValue { get; set; }
        public Signal OutputShiftedSignal { get; set; }

        public override void Run()
        {
            List<float> sample = new List<float>();
            if (InputSignal.Periodic == true)    // +ve negative = right      //   zai ba3d left   //folded
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    if (ShiftingValue < 0) { InputSignal.SamplesIndices[i] = InputSignal.SamplesIndices[i] + ShiftingValue; }    //left
                    else InputSignal.SamplesIndices[i] = InputSignal.SamplesIndices[i] + ShiftingValue;   //ymeen
                }
            }

            else if (InputSignal.Periodic == false)  //didnt fold
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    if (ShiftingValue < 0) { InputSignal.SamplesIndices[i] = InputSignal.SamplesIndices[i] - ShiftingValue; }  //right
                    else InputSignal.SamplesIndices[i] = InputSignal.SamplesIndices[i] - ShiftingValue;   //left 
                }
            }

            //for (int i = 0; i < InputSignal.Samples.Count; i++)
            //{
            //    sample.Add(InputSignal.Samples[i]);
            //}
            //OutputShiftedSignal = new Signal(sample, false);
            OutputShiftedSignal = InputSignal;
       


        }
    }
}
