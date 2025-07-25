using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Input_Model : Process, IHas_Begin
    {
        [field: SerializeField] public bool inputDown { get; private set; }
        [field: SerializeField] public bool input { get; private set; }
        [field: SerializeField] public bool inputUp { get; private set; }
        [field: SerializeField] public Vector2 input_vector2 { get; private set; }
        [field: SerializeField] public float input_distance { get; private set; }
        [field: SerializeField] public float input_radian { get; private set; }

        public event UnityAction<bool> Get_inputDown_Action;
        public event UnityAction<bool> Get_input_Action;
        public event UnityAction<bool> Get_inputUp_Action;
        public event UnityAction<Vector2> Get_input_vector2_Action;
        public event UnityAction<float> Get_input_distance_Action;
        public event UnityAction<float> Get_input_radian_Action;
        public event UnityAction InputDown_Action;
        public event UnityAction Input_Action;
        public event UnityAction InputUp_Action;

        public Input_Model() : base(nameof(Input_Model)) {}

        protected override void Initialize_Detail()
        {
            inputDown = false;
            input = false;
            inputUp = false;
            input_vector2 = Vector2.zero;
            input_distance = 0f;
            input_radian = 0f;

            Get_inputDown_Action = null;
            Get_input_Action = null;
            Get_inputUp_Action = null;
            Get_input_vector2_Action = null;
            Get_input_distance_Action = null;
            Get_input_radian_Action = null;
        }

        protected override void Begin_Detail()
        {
            Get_inputDown_Action?.Invoke(inputDown);
            Get_input_Action?.Invoke(input);
            Get_inputUp_Action?.Invoke(inputUp);
            Get_input_vector2_Action?.Invoke(input_vector2);
            Get_input_distance_Action?.Invoke(input_distance);
            Get_input_radian_Action?.Invoke(input_radian);
        }

        public void OnInputDown()
        {
            Set_inputDown(true);
            Set_inputUp(false);

            InputDown_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInputDown)}");
        }

        private void Set_inputDown(bool _set)
        {
            inputDown = _set;
            Get_inputDown_Action?.Invoke(inputDown);
        }

        private void Set_inputUp(bool _set)
        {
            inputUp = _set;
            Get_inputUp_Action?.Invoke(inputUp);
        }

        public void OnInput()
        {
            Set_input(true);

            Input_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInput)}");
        }

        private void Set_input(bool _set)
        {
            input = _set;
            Get_input_Action?.Invoke(input);
        }

        public void OnInputUp()
        {
            Set_inputDown(false);
            Set_input(false);
            Set_inputUp(true);

            InputUp_Action?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInputUp)}");
        }

        public void Set_input_vector2(Vector2 _set)
        {
            _Set_input_vector2(_set);
            Set_input_distance();
            Set_input_radian();
        }

        private void _Set_input_vector2(Vector2 _set)
        {
            input_vector2 = _set;
            Get_input_vector2_Action?.Invoke(input_vector2);
        }

        private void Set_input_distance()
        {
            input_distance = Convert.Vector2_To_Distance(input_vector2);
            Get_input_distance_Action?.Invoke(input_distance);
        }
        
        private void Set_input_radian()
        {
            if (input_vector2 != Vector2.zero)
            {
                input_radian = Convert.Vector2_To_Radian(input_vector2);
                Get_input_radian_Action?.Invoke(input_radian);
            }
        }
    }
}