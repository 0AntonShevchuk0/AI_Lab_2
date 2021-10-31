using System;

namespace AI_Lab_2.NeuronNetwork
{
    public class Neuron
    {
        protected ActivationFunction actFunc;

        public double[] Weights { get; set; }

        public Neuron(ActivationFunction actFunc, int inputCount, double initialWeightValue = 1)
        {
            this.actFunc = actFunc;
            Weights = new double[inputCount];
            for (int i = 0; i < inputCount; i++)
            {
                Weights[i] = initialWeightValue;
            }
        }

        public double GetOutput(double[] inputValues)
        {
            if (inputValues.Length != Weights.Length)
                throw new NeuronNetworkException("Wrong input values number");
            var sum = 0.0d;
            for (int i = 0; i < Weights.Length; i++)
            {
                sum += Weights[i] * inputValues[i];
            }
            return actFunc(sum);
        }
    }
}
