namespace AI_Lab_2.NeuronNetwork
{
    public class NeuronLayer
    {
        public Neuron[] Neurons { get; }
        public int Count => Neurons?.Length ?? 0;

        public Neuron this[int index]
        {
            get
            {
                if (index >= 0 && index < Neurons.Length)
                    return Neurons[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 && index < Neurons.Length)
                    Neurons[index] = value;
                else
                    throw new NeuronNetworkException("Wrong neuron layer index");
            }
        }

        public NeuronLayer(Neuron[] neurons)
        {
            Neurons = neurons;
        }
    }
}
