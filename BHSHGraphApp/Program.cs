using BHSHGraphApp.Graph;
using BHSHGraphApp.Graph.Blocks;
using System;

namespace BHSHGraphApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var entryPointAdderSlot = new OutputSlot<Object>();
            var adderLinkSlot1 = new InputSlot<Object>();

            var constSlot1 = new OutputSlot<int>();
            constSlot1.AddData(5);
            var constSlot2 = new OutputSlot<int>();
            constSlot2.AddData(7);

            var adderInputSlot1 = new InputSlot<int>();
            var adderInputSlot2 = new InputSlot<int>();

            var adderOutputSlot = new OutputSlot<int>();
            var printerInputSlot = new InputSlot<int>();

            var entryAdderConnection1 = new Connection<int>(constSlot1);
            var entryAdderConnection2 = new Connection<int>(constSlot2);

            var adderEntryConnection1 = new Connection<int>(adderInputSlot1);
            var adderEntryConnection2 = new Connection<int>(adderInputSlot2);

            var entryPointAdderConnection = new Connection<Object>(adderLinkSlot1);

            var adderPrinterConnection = new Connection<int>(printerInputSlot);

            adderInputSlot1.AddConnection(entryAdderConnection1);
            adderInputSlot2.AddConnection(entryAdderConnection2);

            entryPointAdderSlot.AddConnection(entryPointAdderConnection);

            constSlot1.AddConnection(adderEntryConnection1);
            constSlot2.AddConnection(adderEntryConnection2);

            adderOutputSlot.AddConnection(adderPrinterConnection);

            var entryPointBlock = new EntryPointBlock<Object>(entryPointAdderSlot);
            var adderBlock = new Adder<Object, int>(adderLinkSlot1, adderOutputSlot);

            adderBlock.addDataProviders(adderInputSlot1);
            adderBlock.addDataProviders(adderInputSlot2);

            var constBlock1 = new ConstBlock<int>(constSlot1);
            var constBlock2 = new ConstBlock<int>(constSlot2);
            var printerBlock = new PrinterBlock<int>(printerInputSlot);

            entryPointBlock.Run();
        }
    }
}
