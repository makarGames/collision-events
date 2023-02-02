using System;
using UnityEngine;

namespace Game.Scripts.CollisionEvents
{
    [Flags]
    public enum InteractType
    {
        CollisionEnter = 1,
        CollisionExit = 2,
        TriggerEnter = 3,
        TriggerExit = 4,
    }

    [RequireComponent(typeof(Collider))]
    public class PhysicalInteractChecker : MonoBehaviour
    {
        [SerializeField] private InteractType _interactType;

        public event Action<Collision> OnCollisionEnteredEvent;
        public event Action<Collision> OnCollisionExitEvent;
        public event Action<Collider> OnTriggerEnteredEvent;
        public event Action<Collider> OnTriggerExitEvent;

        private void OnCollisionEnter(Collision other)
        {
            if ((_interactType & InteractType.CollisionEnter) != 0)
            {
                OnCollisionEnteredEvent?.Invoke(other);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if ((_interactType & InteractType.CollisionExit) != 0)
            {
                OnCollisionExitEvent?.Invoke(other);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((_interactType & InteractType.TriggerEnter) != 0)
            {
                OnTriggerEnteredEvent?.Invoke(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if ((_interactType & InteractType.TriggerExit) != 0)
            {
                OnTriggerExitEvent?.Invoke(other);
            }
        }
    }
}