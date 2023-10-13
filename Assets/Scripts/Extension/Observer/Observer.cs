using System;
using UnityEngine;

namespace Extension.Observer
{
    public abstract class Observer : MonoBehaviour
    {
        public Subject Subject;

        private void OnEnable()
        {
            Subject.Action += DoSomething;
        }

        public abstract void DoSomething();

        private void OnDisable()
        {
            Subject.Action -= DoSomething;
        }
    }
}