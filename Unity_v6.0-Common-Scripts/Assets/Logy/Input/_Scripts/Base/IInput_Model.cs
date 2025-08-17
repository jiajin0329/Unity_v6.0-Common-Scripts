using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IInput_Model
    {
        public bool inputDown { get; }
        public bool input { get; }
        public bool inputUp { get; }
        public bool is_input => inputDown || input;
        public Vector2 input_vector2 { get; }
        public float input_distance { get; }
        public float input_radian { get; }
        
        public event UnityAction InputDown_Action;
        public event UnityAction Input_Action;
        public event UnityAction InputUp_Action;
    }
}