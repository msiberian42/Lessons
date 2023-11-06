using UnityEngine;

namespace MVC
{
    public abstract class ControllerBase : MonoBehaviour
    {
        protected ViewBase view;
        protected ModelBase model;

        protected float moveSpeed;

        protected virtual void OnEnable()
        {
            model.OnMoveSpeedChangedEvent += OnMoveSpeedChanged;
        }
        protected virtual void OnDisable()
        {
            model.OnMoveSpeedChangedEvent -= OnMoveSpeedChanged;
        }

        protected abstract void MoveCharacter();

        protected void OnMoveSpeedChanged(float value)
        {
            moveSpeed = value;
        }
        public void SetLookingDirectionToView(LookingDirection direction)
        {
            view.SetLookingDirection(direction);
        }
        public void OnPlayerIdleStatement()
        {
            view.OnPlayerIdleStatement();
        }
        public void OnPlayerMoving()
        {
            view.OnPlayerMoving();
        }
    }   
}
