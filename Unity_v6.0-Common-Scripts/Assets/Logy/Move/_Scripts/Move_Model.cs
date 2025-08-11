using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Move_Model : IMove_Model
    {
        public const float speed = 2.5f;
        private const float _acceleration = 7.5f;
        private const float _slowDown = 7.5f;
        private IInput_Model _input_model;
        [field: SerializeField]
        public Vector2 velocity { get; private set; }
        [field: SerializeField]
        public float speed_ratio { get; private set; }
        [field: SerializeField]
        public float move_radian { get; private set; }

        public event UnityAction Tick_Action;

        public void Set_Reference(IInput_Model _input_model) { this._input_model = _input_model; }

        public void Initialize()
        {
            velocity = Vector2.zero;
        }

        public void Tick()
        {
            Calculate_Move_Vector2();

            Tick_Action?.Invoke();
        }

        private void Calculate_Move_Vector2()
        {
            if (Is_Stop()) return;

            Calculate_SlowDown();

            Calculate_Acceleration();

            velocity = Vector2.ClampMagnitude(velocity, speed);

            speed_ratio = velocity.magnitude / speed;
            move_radian = Convert.Vector2_To_Radian(velocity);
        }

        private bool Is_Stop()
        {
            return !Is_Input() && velocity.magnitude < 0.01f;
        }

        private bool Is_Input()
        {
            return _input_model.input_distance > 0.2f;
        }

        private void Calculate_Acceleration()
        {
            if (!Is_Input()) return;

            Vector2 _desired_velocity = _input_model.input_vector2 * speed;
            Vector2 _steering = _desired_velocity - velocity;

            float _acceleration_fixedDeltaTime =  (_acceleration + _slowDown) * Time.fixedDeltaTime;
            _steering = Vector2.ClampMagnitude(_steering, _acceleration_fixedDeltaTime);
            velocity += _steering;
        }

        private void Calculate_SlowDown()
        {
            if (Velocity_Is_Input_Vector2()) return;

            Vector2 _desired_velocity = Vector2.zero;
            Vector2 _steering = _desired_velocity - velocity;
            float _slowDown_fixedDeltaTime = _slowDown * Time.fixedDeltaTime;
            _steering = Vector2.ClampMagnitude(_steering, _slowDown_fixedDeltaTime);
            velocity += _steering;
        }

        private bool Velocity_Is_Input_Vector2()
        {
            return velocity == _input_model.input_vector2 * speed;
        }
    }
}