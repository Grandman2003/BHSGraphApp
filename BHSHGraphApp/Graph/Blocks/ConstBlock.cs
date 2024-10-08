using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Graph.Blocks
{
    internal class ConstBlock<C> : BaseBlock<Object, C>,IInputBlock<C>
    {
        public ConstBlock(OutputSlot<C> outputSlot) : base(null, outputSlot)
        {
            outputSlot.AddObserver(data => Run());
        }

        public OutputSlot<C> GetOutput() => Output;

        public override void Run()
        {
            Output.TriggerConnections();
        }
    }
}
