using System;
using UnityEngine;

namespace Game.Scripts.CollisionEvents
{
    public class CollisionEvents<T>
    {
        public event Action<T> OnTargetTriggerEnteredEvent;
        public event Action<T> OnTargetTriggerExitEvent;
        public event Action<T> OnTargetTriggerStaysEvent;
        public event Action<T> OnTargetCollisionEnteredEvent;
        public event Action<T> OnTargetCollisionExitEvent;

        public CollisionEvents(CollisionChecker collisionChecker)
        {
            collisionChecker.OnTriggerEnteredEvent += CheckTargetTriggerEntered;
            collisionChecker.OnTriggerExitEvent += CheckTargetTriggerExit;
            collisionChecker.OnTriggerStaysEvent += CheckTargetTriggerStays;
            collisionChecker.OnCollisionEnteredEvent += CheckTargetCollisionEntered;
            collisionChecker.OnCollisionExitEvent += CheckTargetCollisionExit;
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

        private void CheckTargetTriggerStays(Collider other)
        {
            var targetComponent = other.GetComponent<T>();

            if (targetComponent != null)
            {
                OnTargetTriggerStaysEvent?.Invoke(targetComponent);
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