using System;
using UnityEngine;

namespace Game.Scripts.CollisionEvents
{
    public class InteractEvents<T>
    {
        public event Action<T> OnTargetCollisionEnteredEvent;
        public event Action<T> OnTargetCollisionExitEvent;
        public event Action<T> OnTargetTriggerEnteredEvent;
        public event Action<T> OnTargetTriggerExitEvent;

        public InteractEvents(PhysicalInteractChecker physicalInteractChecker)
        {
            physicalInteractChecker.OnCollisionEnteredEvent += CheckTargetCollisionEntered;
            physicalInteractChecker.OnCollisionExitEvent += CheckTargetCollisionExit;
            physicalInteractChecker.OnTriggerEnteredEvent += CheckTargetTriggerEntered;
            physicalInteractChecker.OnTriggerExitEvent += CheckTargetTriggerExit;
        }

        private void CheckTargetTriggerEntered(Collider other)
        {
            var targetComponent = other.GetComponent<T>();

            if (targetComponent != null)
            {
                OnTargetTriggerEnteredEvent?.Invoke(targetComponent);
            }
        }

        private void CheckTargetTriggerExit(Collider other)
        {
            var targetComponent = other.GetComponent<T>();

            if (targetComponent != null)
            {
                OnTargetTriggerExitEvent?.Invoke(targetComponent);
            }
        }

        private void CheckTargetCollisionEntered(Collision other)
        {
            var targetComponent = other.gameObject.GetComponent<T>();

            if (targetComponent != null)
            {
                OnTargetCollisionEnteredEvent?.Invoke(targetComponent);
            }
        }


        private void CheckTargetCollisionExit(Collision other)
        {
            var targetComponent = other.gameObject.GetComponent<T>();

            if (targetComponent != null)
            {
                OnTargetCollisionExitEvent?.Invoke(targetComponent);
            }
        }
    }
}