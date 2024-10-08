using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Graph.Blocks
{
    internal class EntryPointBlock<O> : BaseBlock<Object,O>, IInputBlock<O>
    {
        public EntryPointBlock(OutputSlot<O> outputSlot) : base(null, outputSlot)
        {
        }

        public OutputSlot<O> GetOutput() => Output;

        public override void Run()
        {
            Output.TriggerConnections();
        }
    }
}
