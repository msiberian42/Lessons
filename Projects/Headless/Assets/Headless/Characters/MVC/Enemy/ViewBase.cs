using UnityEngine;

namespace EnemyMVC
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] protected ModelBase model;

        public abstract void OnStateChanged(State state, Direction direction);
    }
}
