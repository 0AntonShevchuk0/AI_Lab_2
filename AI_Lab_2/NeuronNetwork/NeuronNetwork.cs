using System;
using System.Drawing;

namespace AI_Lab_2.NeuronNetwork
{
    public delegate double ActivationFunction(double param);

    public class NeuronNetwork
    {
        public Topology Topology { get; }

        public NeuronLayer[] layers;

        private ActivationFunction actFunc;

        private Image[] dataset;

        public NeuronNetwork(Topology topology, ActivationFunction actFunc, Image[] dataset)
        {
            Topology = topology;
            this.actFunc = actFunc;
            this.dataset = dataset;

            layers = new NeuronLayer[topology.HiddenLayersNeurons.Length + 2];

            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();
        }

        public void CreateInputLayer()
        {
            var inputLayerNeurons = new Neuron[Topology.InputLayerNeurons];
            for (int i = 0; i < inputLayerNeurons.Length; i++)
            {
                inputLayerNeurons[i] = new Neuron(actFunc, 1);
            }
            var inputLayer = new NeuronLayer(inputLayerNeurons);
            layers[0] = inputLayer;
        }

        public void CreateHiddenLayers()
        {
            for (int i = 0; i < Topology.HiddenLayersNeurons.Length; i++)
            {
                var hidenLayerNeurons = new Neuron[Topology.HiddenLayersNeurons[i]];
                for (int j = 0; j < hidenLayerNeurons.Length; j++)
                {
                    hidenLayerNeurons[j] = new Neuron(actFunc, layers[i].Count);
                }
                var hiddenLayer = new NeuronLayer(hidenLayerNeurons);
                layers[i + 1] = hiddenLayer;
            }
        }

        public void CreateOutputLayer()
        {
            var outputLayerNeurons = new Neuron[Topology.OutputLayerNeurons];
            for (int i = 0; i < outputLayerNeurons.Length; i++)
            {
                outputLayerNeurons[i] = new Neuron(actFunc, layers[layers.Length - 2].Count);
            }
            var outputLayer = new NeuronLayer(outputLayerNeurons);
            layers[layers.Length - 1] = outputLayer;
        }

        private void Study()
        {

        }

        public double getValue(double[] data)
        {
            if (data.Length != Topology.InputLayerNeurons)
                throw new NeuronNetworkException("Wrong input signals count");
            var outputs = new double[data.Length];
            for (int i = 0; i < layers[0].Count; i++)
            {
                outputs[i] = layers[0][i].GetOutput(new[] { data[i] });
            }
            for (int i = 1; i < layers.Length; i++)
            {
                var newOutputs = new double[layers[i].Count];
                for (int j = 0; j < layers[i].Count; j++)
                {
                    newOutputs[j] = layers[i][j].GetOutput(outputs);
                }
                outputs = new double[newOutputs.Length];
                newOutputs.CopyTo(outputs, 0);
            }
            return outputs[0];
        }
    }
}
