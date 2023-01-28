using System;
using UnityEngine;

namespace Game.Scripts.CollisionEvents
{
    public class CollisionChecker : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEnteredEvent;
        public event Action<Collider> OnTriggerExitEvent;
        public event Action<Collider> OnTriggerStaysEvent;
        public event Action<Collision> OnCollisionEnteredEvent;
        public event Action<Collision> OnCollisionExitEvent;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnteredEvent?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitEvent?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerStaysEvent?.Invoke(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            OnCollisionEnteredEvent?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            OnCollisionExitEvent?.Invoke(other);
        }
    }
}