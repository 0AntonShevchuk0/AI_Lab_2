namespace AI_Lab_2.NeuronNetwork
{
    public class Topology
    {
        public int InputLayerNeurons { get; }
        public int OutputLayerNeurons { get; }

        public int[] HiddenLayersNeurons { get; }

        public Topology(int inputLayerNeurons, int outputLayerNeurons, params int[] hiddenLayersNeurons)
        {
            InputLayerNeurons = inputLayerNeurons;
            OutputLayerNeurons = outputLayerNeurons;
            HiddenLayersNeurons = new int[hiddenLayersNeurons.Length];
            hiddenLayersNeurons.CopyTo(HiddenLayersNeurons, 0);
        }
    }
}
