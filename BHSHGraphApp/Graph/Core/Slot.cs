using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Graph
{
    internal abstract class Slot<T>
    {
        public T SlotData { get; protected set; }

        private List<Action<T>> observers = new List<Action<T>>();

        protected readonly List<Connection<T>> connections = new List<Connection<T>>();
        public abstract void AddConnection(Connection<T> newConnection);
        public void AddData(T data)
        {
            SlotData = data;
        }

        public void Invoke(T data)
        {
            observers.ForEach(x => x.Invoke(data));
        }

        public void AddObserver(Action<T> action)
        {
            observers.Add(action);
        }

        public void TriggerConnections() => connections.ForEach(connection => connection.flowData(SlotData));
    }

    internal sealed class InputSlot<T> : Slot<T>
    {

        public override void AddConnection(Connection<T> newConnection)
        {

            connections.Add(newConnection);
        }
    }

    internal sealed class OutputSlot<T> : Slot<T>
    { 

        public override void AddConnection(Connection<T> newConnection)
        {

            connections.Add(newConnection);
        }
    }
}
