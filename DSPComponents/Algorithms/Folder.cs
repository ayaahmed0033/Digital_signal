using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            List<float> sample = new List<float>();
            List<int> sampleI = new List<int>();// added by Manar
            for (int i = InputSignal.Samples.Count - 1; i >= 0; i--)
            {
                sample.Add(InputSignal.Samples[i]);
                sampleI.Add(InputSignal.SamplesIndices[i] * -1);// added by Manar
            }
            if (InputSignal.Periodic)
            {
                OutputFoldedSignal = new Signal(sample, sampleI, false);
            }
            else
            {
                OutputFoldedSignal = new Signal(sample, sampleI, true);
            }


        }
    }
}

