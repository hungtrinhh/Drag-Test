using UnityEngine;

namespace IState
{
    public interface IStateDroppable
    {
        public void Execute();
    }

    public class HasChild : IStateDroppable
    {
        private Transform _transform;

        HasChild(Transform transform)
        {
            _transform = transform;
        }

        public void Execute()
        {
            _transform.GetChild(0).SetParent(Draggable.Parent);
            Draggable.Parent = _transform;
        }
    }

    public class Has0Child : IStateDroppable
    {
        private Transform _transform;

        Has0Child(Transform transform)
        {
            _transform = transform;
        }

        public void Execute()
        {
            Debug.Log("Drop " + _transform.name);
            Draggable.Parent = _transform;
        }
    }
}