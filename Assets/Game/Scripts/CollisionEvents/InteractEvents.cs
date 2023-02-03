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

        private void CheckTargetCollisionEntered(Collision other) => CheckInteraction(other, OnTargetCollisionEnteredEvent);
        private void CheckTargetCollisionExit(Collision other) => CheckInteraction(other, OnTargetCollisionExitEvent);
        private void CheckTargetTriggerEntered(Collider other) => CheckInteraction(other, OnTargetTriggerEnteredEvent);
        private void CheckTargetTriggerExit(Collider other) => CheckInteraction(other, OnTargetTriggerExitEvent);

        private void CheckInteraction(Collision other, Action<T> onInteract)
        {
            var isContain = other.gameObject.TryGetComponent<T>(out var targetComponent);

            if (isContain)
            {
                onInteract?.Invoke(targetComponent);
            }
        }
        
        private void CheckInteraction(Component other, Action<T> onInteract)
        {
            var isContain = other.TryGetComponent<T>(out var targetComponent);

            if (isContain)
            {
                onInteract?.Invoke(targetComponent);
            }
        }
    }
}