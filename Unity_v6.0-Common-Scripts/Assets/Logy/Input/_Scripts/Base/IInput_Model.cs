using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface IInput_Model 
    {
        public bool inputDown { get; }
        public bool input { get; }
        public bool inputUp { get; }
        public Vector2 input_vector2 { get; }
        public float input_distance { get; }
        public float input_radian { get; }
        
        public event UnityAction InputDown_Action;
        public event UnityAction Input_Action;
        public event UnityAction InputUp_Action;
    }
}