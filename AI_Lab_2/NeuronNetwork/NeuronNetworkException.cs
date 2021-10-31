using System;
using System.Runtime.Serialization;

namespace AI_Lab_2.NeuronNetwork
{
    public class NeuronNetworkException : Exception
    {
        public NeuronNetworkException(string message) : base(message) {}

        public NeuronNetworkException(string message, Exception innerException) : base(message, innerException) {}

        protected NeuronNetworkException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
