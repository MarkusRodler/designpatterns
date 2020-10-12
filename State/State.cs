using System;

namespace StatePattern
{
    public interface DoorState
    {
        DoorState close();
        DoorState lockIt();
        DoorState open();
        DoorState unlock();
        void setContext(Door door);
    }

    abstract class AbstractDoorState : DoorState
    {
        public virtual DoorState open() => throw new IllegalStateTransitionException();
        public virtual DoorState close() => throw new IllegalStateTransitionException();
        public virtual DoorState lockIt() => throw new IllegalStateTransitionException();
        public virtual DoorState unlock() => throw new IllegalStateTransitionException();
        protected Door door;

        public void setContext(Door door)
        {
            this.door = door;
        }
    }

    public class IllegalStateTransitionException : Exception
    {
    }

    class OpenedDoorState : AbstractDoorState
    {
        public override DoorState close() => new ClosedDoorState();
    }

    class ClosedDoorState : AbstractDoorState
    {
        public override DoorState open() => new OpenedDoorState();
        public override DoorState lockIt() => new LockedDoorState();
    }

    class LockedDoorState : AbstractDoorState
    {
        public override DoorState unlock() => new ClosedDoorState();
    }

    public class Door
    {
        private DoorState state;

        public Door(DoorState state)
        {
            transitionTo(state);
        }

        public void open()
        {
            transitionTo(state.open());
        }

        public void close()
        {
            transitionTo(state.close());
        }

        public void lockIt()
        {
            transitionTo(state.lockIt());
        }

        public void unlock()
        {
            transitionTo(state.unlock());
        }

        private void transitionTo(DoorState state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.\n");
            this.state = state;
            this.state.setContext(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var door = new Door(new OpenedDoorState());
            door.close(); // => ClosedDoorState
            door.lockIt(); // => LockedDoorState
            door.lockIt(); // => Exception
        }
    }
}
