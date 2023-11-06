using System;
using UnityEngine;

namespace MVC
{
    public abstract class ModelBase : MonoBehaviour
    {
        [SerializeField] protected float _moveSpeed;

        public float moveSpeed { get; protected set; }
        public event Action<float> OnMoveSpeedChangedEvent;

        protected virtual void Awake()
        {
            moveSpeed = _moveSpeed;
        }
        protected void OnMoveSpeedChanged()
        {
            OnMoveSpeedChangedEvent?.Invoke(moveSpeed);
        }
    }
}
