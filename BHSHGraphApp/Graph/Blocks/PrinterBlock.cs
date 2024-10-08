using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Graph.Blocks
{
    internal class PrinterBlock<I> : BaseBlock<I, Object>, IOutputBlock<I>
    {
        public PrinterBlock(InputSlot<I> inputSlot) : base(inputSlot, null)
        {
            inputSlot.AddObserver(data =>
            {
                inputSlot.AddData(data);
                Run();
            }
            );
        }

        public InputSlot<I> GetInput() => Input;

        public override void Run()
        {
            Console.WriteLine(Input.SlotData);
        }
    }
}
