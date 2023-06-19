using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DCT : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float>samples=new List<float>();
            
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                float sum = 0;
                for (int j = 0; j < InputSignal.Samples.Count; j++)
                {
                    sum += InputSignal.Samples[j] *(float) Math.Cos((float)(Math.PI /( 4.0f * (float)InputSignal.Samples.Count)) * ((2.0f * j) - 1.0f) * ((2.0f * i) - 1.0f));
                }
               samples.Add((float)(Math.Sqrt(2.0f / (float)InputSignal.Samples.Count) * sum));

            }
            OutputSignal= new Signal(samples,false);
           
        }
    }
}
