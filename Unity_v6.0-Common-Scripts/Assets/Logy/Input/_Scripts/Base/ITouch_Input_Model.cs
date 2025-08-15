using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface ITouch_Input_Model
    {
        public Vector2 start_touch_vector2 { get; }
        public Vector2 touch_vector2 { get; }
        public float touch_range_radius_pixel { get; }

        public event UnityAction TouchDown_Action;
        public event UnityAction Touch_Action;
        public event UnityAction TouchUp_Action;
    }
}