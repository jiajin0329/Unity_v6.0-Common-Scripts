using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class TouchInputModel : ITouchInputModel
    {
        public const float startTouchRangeRadiusPixel = 100f;
        public float touchRangeRadiusPixel { get; private set; }
        [field: SerializeField]
        public Vector2 startTouchVector2 { get; private set; }
        [field: SerializeField]
        public Vector2 touchVector2 { get; private set; }
        private InputModel _inputModel;

        public event UnityAction TouchDownAction;
        public event UnityAction TouchAction;
        public event UnityAction TouchUpAction;

        public void SetReference(InputModel _inputModel) { this._inputModel = _inputModel; }

        public void Initialize()
        {
            startTouchVector2 = Vector2.zero;
            touchVector2 = Vector2.zero;
            touchRangeRadiusPixel = startTouchRangeRadiusPixel;

            TouchDownAction = null;
            TouchAction = null;
            TouchUpAction = null;
        }

        public void OnTouchDown()
        {
            _inputModel.OnInputDown();
            TouchDownAction?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnTouchDown)}");
        }

        public void OnTouch()
        {
            _inputModel.OnInput();
            TouchAction?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnTouch)}");
        }

        public void OnTouchUp()
        {
            _inputModel.OnInputUp();
            TouchUpAction?.Invoke();

            Debug.Log($"{GetType().Name} {nameof(OnTouchUp)}");
        }

        public void SetStartTouchVector2(Vector2 _set)
        {
            startTouchVector2 = _set;
        }

        public void SetTouchVector2(Vector2 _set)
        {
            touchVector2 = _set;
            Vector2 _input_vector2 = TouchVector2ToInputVector2();
            _inputModel.SetInputVector2(_input_vector2);
        }

        private Vector2 TouchVector2ToInputVector2()
        {
            Vector2 _inputVector2 = touchVector2 - startTouchVector2;
            if (_inputVector2.magnitude > touchRangeRadiusPixel)
            {
                return _inputVector2.normalized;
            }

            return _inputVector2 / touchRangeRadiusPixel;
        }

        public void ResetInputVector2ToZero()
        {
            _inputModel.SetInputVector2(Vector2.zero);
        }
    }
}