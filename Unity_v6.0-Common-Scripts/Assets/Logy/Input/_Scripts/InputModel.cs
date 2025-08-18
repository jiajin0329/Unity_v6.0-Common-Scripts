using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class InputModel : IInputModel
    {
        
        [field: SerializeField]
        public bool inputDown { get; private set; }
        [field: SerializeField]
        public bool input { get; private set; }
        [field: SerializeField]
        public bool inputUp { get; private set; }
        [field: SerializeField]
        public Vector2 inputVector2 { get; private set; }
        [field: SerializeField]
        public float inputRadian { get; private set; }

        public event UnityAction InputDownAction;
        public event UnityAction InputAction;
        public event UnityAction InputUpAction;

        public void Initialize()
        {
            inputDown = false;
            input = false;
            inputUp = false;
            inputVector2 = Vector2.zero;
            inputRadian = 0f;

            InputDownAction = null;
            InputAction = null;
            InputUpAction = null;
        }

        public void OnInputDown()
        {
            inputDown = true;
            inputUp = false;

            InputDownAction?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInputDown)}");
        }

        public void OnInput()
        {
            input = true;

            InputAction?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInput)}");
        }

        public void OnInputUp()
        {
            inputDown = false;
            input = false;
            inputUp = true;

            InputUpAction?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnInputUp)}");
        }

        public void SetInputVector2(Vector2 _set)
        {
            inputVector2 = _set;
            SetInputRadian();
        }
        
        private void SetInputRadian()
        {
            if (inputVector2 != Vector2.zero)
            {
                inputRadian = Convert.Vector2ToRadian(inputVector2);
            }
        }
    }
}