using UnityEngine;

namespace MVC
{
    public abstract class ViewBase : MonoBehaviour
    {
        protected ModelBase model;

        protected LookingDirection lookingDirection;

        public abstract void SetLookingDirection(LookingDirection direction);
        public abstract void OnPlayerIdleStatement();
        public abstract void OnPlayerMoving();
    }
}
