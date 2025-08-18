using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class MoveModel : IMoveModel
    {
        public const float speed = 2.5f;
        private const float _acceleration = 15f;
        private const float _slowDown = 7.5f;
        private IInputModel _inputModel;
        [field: SerializeField]
        public Vector2 velocity { get; private set; }
        [field: SerializeField]
        public float speedRatio { get; private set; }
        [field: SerializeField]
        public float moveRadian { get; private set; }

        public event UnityAction TickAction;

        public void SetReference(IInputModel _inputModel) { this._inputModel = _inputModel; }

        public void Initialize()
        {
            velocity = Vector2.zero;
        }

        public void Tick()
        {
            CalculateMoveVector2();
            TickAction?.Invoke();
        }

        private void CalculateMoveVector2()
        {
            if (IsInput())
                CalculateAcceleration();
            else
                CalculateSlowDown();

            velocity = Vector2.ClampMagnitude(velocity, speed);

            speedRatio = velocity.magnitude / speed;
            moveRadian = Convert.Vector2ToRadian(velocity);
        }

        private bool IsInput()
        {
            return _inputModel.inputVector2.magnitude > 0.2f;
        }

        private void CalculateAcceleration()
        {
            Vector2 _desiredVelocity = _inputModel.inputVector2 * speed;
            Vector2 _steering = _desiredVelocity - velocity;

            float _accelerationFixedDeltaTime =  _acceleration * Time.fixedDeltaTime;
            _steering = Vector2.ClampMagnitude(_steering, _accelerationFixedDeltaTime);
            velocity += _steering;
        }

        private void CalculateSlowDown()
        {
            Vector2 _desiredVelocity = Vector2.zero;
            Vector2 _steering = _desiredVelocity - velocity;
            float _slowDownFixedDeltaTime = _slowDown * Time.fixedDeltaTime;
            _steering = Vector2.ClampMagnitude(_steering, _slowDownFixedDeltaTime);
            velocity += _steering;
        }
    }
}