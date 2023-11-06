using System;
using UnityEngine;

namespace PlayerMVC 
{
    public abstract class ModelBase : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        [SerializeField] private float _jumpForceVertical;
        [SerializeField] private float _jumpForceHorizontal;

        public float moveSpeed { get { return _moveSpeed; } }
        public float jumpForceVertical { get { return _jumpForceVertical; } }
        public float jumpForceHorizontal { get { return _jumpForceHorizontal; } }

        public event Action OnValidateEvent;

        private void OnValidate()
        {
            OnValidateEvent?.Invoke();
        }
    }
}
