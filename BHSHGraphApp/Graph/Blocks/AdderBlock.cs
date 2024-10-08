using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Graph
{
    internal class Adder<E, S> : BaseBlock<E, S>, IInputBlock<S>, IOutputBlock<E>
    {

        private int result = 0;

        public Adder(InputSlot<E> inputSlot, OutputSlot<S> outputSlot) : base(inputSlot, outputSlot)
        {
            Input.AddObserver(data => Run());
        }

        private List<InputSlot<int>> inputSlots = new List<InputSlot<int>>();
        public InputSlot<E> GetInput() => Input;
        public OutputSlot<S> GetOutput() => Output;

        public void addDataProviders(InputSlot<int> provider)
        {
            provider.AddObserver(data => result += data);
            inputSlots.Add(provider);
        }

        public override void Run()
        {
            inputSlots.ForEach(data => data.TriggerConnections());
            Output.AddData((S)(result as Object));
            Output.TriggerConnections();
        }
    }
}
