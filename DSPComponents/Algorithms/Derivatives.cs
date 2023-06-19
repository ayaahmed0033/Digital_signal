using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Derivatives : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal FirstDerivative { get; set; }
        public Signal SecondDerivative { get; set; }
        //First Derivative of input signal  
        // Y(n) = x(n)-x(n-1)
        //Second derivative of input signal
        //Y(n)= x(n+1)-2x(n)+x(n-1)

        public override void Run()
        {
            List<float> sample1 = new List<float>();
            List<float> sample2 = new List<float>();

            sample1.Add(InputSignal.Samples[0]); // added by Manar
            sample2.Add(InputSignal.Samples[1] - 2 * InputSignal.Samples[0]);// added by Manar
            for (int i = 1; i < InputSignal.Samples.Count - 1; i++)
            {
                sample1.Add(InputSignal.Samples[i] - (InputSignal.Samples[i - 1]));
                sample2.Add((InputSignal.Samples[i + 1]) - 2 * (InputSignal.Samples[i]) + (InputSignal.Samples[i - 1]));
            }
            FirstDerivative = new Signal(sample1, false);
            SecondDerivative = new Signal(sample2, false);
        }
    }
}

