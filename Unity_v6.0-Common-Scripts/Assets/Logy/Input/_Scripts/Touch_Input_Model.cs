using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Touch_Input_Model : ITouch_Input_Model
    {
        public const float start_touch_range_radius_pixel = 100f;
        public float touch_range_radius_pixel { get; private set; }
        [field: SerializeField]
        public Vector2 start_touch_vector2 { get; private set; }
        [field: SerializeField]
        public Vector2 touch_vector2 { get; private set; }
        private Input_Model _input_model;

        public event UnityAction TouchDown_Action;
        public event UnityAction Touch_Action;
        public event UnityAction TouchUp_Action;

        public void Set_Reference(Input_Model _input_model) { this._input_model = _input_model; }

        public void Initialize()
        {
            start_touch_vector2 = Vector2.zero;
            touch_vector2 = Vector2.zero;
            touch_range_radius_pixel = start_touch_range_radius_pixel;

            TouchDown_Action = null;
            Touch_Action = null;
            TouchUp_Action = null;
        }

        public void OnTouchDown()
        {
            TouchDown_Action?.Invoke();

            _input_model.OnInputDown();

            Debug.Log($"{GetType().Name} {nameof(OnTouchDown)}");
        }

        public void OnTouch()
        {
            Touch_Action?.Invoke();

            _input_model.OnInput();

            Debug.Log($"{GetType().Name} {nameof(OnTouch)}");
        }

        public void OnTouchUp()
        {
            TouchUp_Action?.Invoke();

            _input_model.OnInputUp();

            Debug.Log($"{GetType().Name} {nameof(OnTouchUp)}");
        }

        public void Set_start_touch_vector2(Vector2 _set)
        {
            start_touch_vector2 = _set;
        }

        public void Set_touch_vector2(Vector2 _set)
        {
            touch_vector2 = _set;
            Vector2 _input_vector2 = Touch_Vector2_To_Input_Vector2();
            _input_model.Set_input_vector2(_input_vector2);
        }

        private Vector2 Touch_Vector2_To_Input_Vector2()
        {
            Vector2 _input_vector2 = touch_vector2 - start_touch_vector2;
            if (_input_vector2.magnitude > touch_range_radius_pixel)
            {
                return _input_vector2.normalized;
            }

            return _input_vector2 / touch_range_radius_pixel;
        }

        public void Reset_input_vector2_To_Zero()
        {
            _input_model.Set_input_vector2(Vector2.zero);
        }
    }
}