using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Touch_Input_Model : Process, IHas_Begin
    {
        [field: SerializeField] public Vector2 start_touch_vector2 { get; private set; }
        [field: SerializeField] public Vector2 touch_vector2 { get; private set; }
        public const float start_touch_range_radius_pixel = 100f;
        public float touch_range_radius_pixel { get; private set; }

        public event UnityAction<Vector2> Get_start_touch_vector2_Action;
        public event UnityAction<Vector2> Get_touch_vector2_Action;
        public event UnityAction<float> Get_touch_range_radius_pixel_Action;
        public event UnityAction<Vector2> Get_input_vector2_Action;
        public event UnityAction TouchDown_Action;
        public event UnityAction Touch_Action;
        public event UnityAction TouchUp_Action;

        public Touch_Input_Model() : base(nameof(Touch_Input_Model)) {}

        protected override void Initialize_Detail()
        {
            start_touch_vector2 = Vector2.zero;
            touch_vector2 = Vector2.zero;
            touch_range_radius_pixel = start_touch_range_radius_pixel;

            Get_start_touch_vector2_Action = null;
            Get_touch_vector2_Action = null;
            Get_touch_range_radius_pixel_Action = null;
            Get_input_vector2_Action = null;
            TouchDown_Action = null;
            Touch_Action = null;
            TouchUp_Action = null;
        }

        protected override void Begin_Detail()
        {
            Get_start_touch_vector2_Action?.Invoke(start_touch_vector2);
            Get_touch_vector2_Action?.Invoke(touch_vector2);
            Get_touch_range_radius_pixel_Action?.Invoke(touch_range_radius_pixel);
            Get_input_vector2_Action?.Invoke(Vector2.zero);
        }

        public void OnTouchDown()
        {
            TouchDown_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnTouchDown)}");
        }

        public void OnTouch()
        {
            Touch_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnTouch)}");
        }

        public void OnTouchUp()
        {
            TouchUp_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnTouchUp)}");
        }

        public void Set_touch_start_vector2(Vector2 _set)
        {
            start_touch_vector2 = _set;
            Get_start_touch_vector2_Action?.Invoke(start_touch_vector2);

            Get_input_vector2_Action?.Invoke(Vector2.zero);
        }

        public void Set_touch_vector2(Vector2 _set)
        {
            touch_vector2 = _set;
            Get_touch_vector2_Action?.Invoke(touch_vector2);

            Get_input_vector2_Action?.Invoke(Touch_Vector2_To_Input_Vector2());
        }

        private Vector2 Touch_Vector2_To_Input_Vector2()
        {
            Vector2 _input_vector2 = touch_vector2 - start_touch_vector2;
            if (Convert.Vector2_To_Distance(_input_vector2) > touch_range_radius_pixel)
            {
                return _input_vector2.normalized;
            }

            return _input_vector2 / touch_range_radius_pixel;
        }
        
        private void Set_touch_range_radius_pixel(float _set)
        {
            touch_range_radius_pixel = _set;
            Get_touch_range_radius_pixel_Action?.Invoke(touch_range_radius_pixel);
        }
    }
}