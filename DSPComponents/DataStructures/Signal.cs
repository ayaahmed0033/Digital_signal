﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.DataStructures
{
    public class Signal
    {
        private List<double> sample;
        private bool v;
        private List<double> samples;

        public List<float> Samples { get; set; }
        public List<int> SamplesIndices { get; set; }
        public List<float> Frequencies { get; set; }
        public List<float> FrequenciesAmplitudes { get; set; }
        public List<float> FrequenciesPhaseShifts { get; set; }
        public bool Periodic { get; set; }

        public Signal(List<float> _SignalSamples, bool _periodic)
        {
            Samples = _SignalSamples;
            Periodic = _periodic;
            SamplesIndices = new List<int>(_SignalSamples.Count);

            for (int i = 0; i < _SignalSamples.Count; i++)
                SamplesIndices.Add(i);
        }

        internal void add(float v)
        {
            throw new NotImplementedException();
        }

        public Signal(List<float> _SignalSamples, List<int> _SignalIndixes, bool _periodic)
        {
            Samples = _SignalSamples;
            Periodic = _periodic;
            SamplesIndices = _SignalIndixes;
        }
        public Signal(bool _periodic, List<float> _SignalFrquencies, List<float> _SignalFrequenciesAmplitudes, List<float> _SignalFrequenciesPhaseShifts)
        {
            Periodic = _periodic;
            Frequencies = _SignalFrquencies;
            FrequenciesAmplitudes = _SignalFrequenciesAmplitudes;
            FrequenciesPhaseShifts = _SignalFrequenciesPhaseShifts;
        }
        public Signal(List<float> _SignalSamples, bool _periodic, List<float> _SignalFrequencies, List<float> _SignalFrequenciesAmplitudes, List<float> _SignalFrequenciesPhaseShifts)
        {
            Periodic = _periodic;
            Samples = _SignalSamples;
            SamplesIndices = new List<int>(_SignalSamples.Count);

            for (int i = 0; i < _SignalSamples.Count; i++)
                SamplesIndices.Add(i);

            Frequencies = _SignalFrequencies;
            FrequenciesAmplitudes = _SignalFrequenciesAmplitudes;
            FrequenciesPhaseShifts = _SignalFrequenciesPhaseShifts;
        }
        public Signal(List<float> _SignalSamples, List<int> _SignalIndixes, bool _periodic, List<float> _SignalFrequencies, List<float> _SignalFrequenciesAmplitudes, List<float> _SignalFrequenciesPhaseShifts)
        {
            Samples = _SignalSamples;
            Periodic = _periodic;
            SamplesIndices = _SignalIndixes;
            Frequencies = _SignalFrequencies;
            FrequenciesAmplitudes = _SignalFrequenciesAmplitudes;
            FrequenciesPhaseShifts = _SignalFrequenciesPhaseShifts;
        }

        public Signal(List<double> sample, List<int> samplesIndices, bool v)
        {
            this.sample = sample;
            this.v = v;
        }

        public Signal(List<double> samples, bool v)
        {
            this.samples = samples;
            this.v = v;
        }

        public static implicit operator List<object>(Signal v)
        {
            throw new NotImplementedException();
        }
    }
}
