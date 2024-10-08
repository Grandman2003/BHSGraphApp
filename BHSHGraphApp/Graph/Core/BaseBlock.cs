using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Graph
{
    internal abstract class BaseBlock<I, O>
    {
        protected InputSlot<I> Input { get; }
        protected OutputSlot<O> Output { get; }
        protected BaseBlock(InputSlot<I> inputSlot, OutputSlot<O> outputSlot)
        {
            Input = inputSlot;
            Output = outputSlot;
        }

        public abstract void Run();
    }

    internal interface IInputBlock<O>
    {
       OutputSlot<O> GetOutput();
    }

    internal interface IOutputBlock<I>
    {
        InputSlot<I> GetInput();
    }
}
