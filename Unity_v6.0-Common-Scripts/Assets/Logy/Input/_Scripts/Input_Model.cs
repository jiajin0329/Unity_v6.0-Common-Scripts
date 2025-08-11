using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Input_Model : IInput_Model
    {
        [field: SerializeField] public bool inputDown { get; private set; }
        [field: SerializeField] public bool input { get; private set; }
        [field: SerializeField] public bool inputUp { get; private set; }
        [field: SerializeField] public Vector2 input_vector2 { get; private set; }
        [field: SerializeField] public float input_distance { get; private set; }
        [field: SerializeField] public float input_radian { get; private set; }

        public event UnityAction InputDown_Action;
        public event UnityAction Input_Action;
        public event UnityAction InputUp_Action;

        public void Initialize()
        {
            inputDown = false;
            input = false;
            inputUp = false;
            input_vector2 = Vector2.zero;
            input_distance = 0f;
            input_radian = 0f;

            InputDown_Action = null;
            Input_Action = null;
            InputUp_Action = null;
        }

        public void OnInputDown()
        {
            inputDown = true;
            inputUp = false;

            InputDown_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInputDown)}");
        }

        public void OnInput()
        {
            input = true;

            Input_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInput)}");
        }

        public void OnInputUp()
        {
            inputDown = false;
            input = false;
            inputUp = true;

            InputUp_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInputUp)}");
        }

        public void Set_input_vector2(Vector2 _set)
        {
            input_vector2 = _set;

            Set_input_distance();
            Set_input_radian();
        }

        private void Set_input_distance()
        {
            input_distance = input_vector2.magnitude;
        }
        
        private void Set_input_radian()
        {
            if (input_vector2 != Vector2.zero)
            {
                input_radian = Convert.Vector2_To_Radian(input_vector2);
            }
        }
    }
}