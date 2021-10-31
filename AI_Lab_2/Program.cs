using System;

namespace AI_Lab_2.NeuronNetwork
{
    public class Program
    {
        static void Main(string[] args)
        {
            Topology testTopology = new Topology(3, 2, 4, 3);
            NeuronNetwork nn = new NeuronNetwork(testTopology, (x) => x, null);
            Console.WriteLine(nn.getValue(new[] { 1.0d, 1.0d, 1.0d }));
        }

        public double BasicFunction(double argument)
        {
            return argument;
        }
    }
}
