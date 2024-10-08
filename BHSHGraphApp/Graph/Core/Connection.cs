using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Graph
{
    internal class Connection<T>
    {
        public Slot<T> Target { get; }
        public Connection(Slot<T> target) { 
            Target = target;
            //Target.AddConnection(this);
        }

        public void flowData(Object data)
        {
            Target.Invoke((T)data);
        }
    }
}
