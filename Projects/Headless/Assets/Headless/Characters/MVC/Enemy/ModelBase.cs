using UnityEngine;
using System;

namespace EnemyMVC
{
    public abstract class ModelBase : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] protected float _aggroDistance;
        [SerializeField] protected float _attackDistance;

        public float moveSpeed { get { return _moveSpeed; } }
        public float aggroDistance { get { return _aggroDistance; } }
        public float attackDistance { get { return _attackDistance; } }

        public event Action OnValidateEvent;

        private void OnValidate()
        {
            OnValidateEvent?.Invoke();
        }
    }
}
