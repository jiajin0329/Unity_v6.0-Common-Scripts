#if UNITY_WEBGL
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class ControllerInputActionGeneric : ControllerInputAction
    {
        private InputAction _touchPressInputAction;
        private TouchInputModel _touchInputModel;

        public bool isTouchPressInputActionNotNull => _touchPressInputAction != null;

        public void SetReference(TouchInputModel _touch, InputModel _input)
        {
            _touchInputModel = _touch;
            SetReference(_input);
        }

        public override async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await base.InitializeWithUniTask(_cancellationToken);

            VariableInitialize();
            AddMoveInputActionListener();
        }

        private void VariableInitialize()
        {
            _touchPressInputAction = _inputActionAsset.FindAction("Player/TouchPress");
            _touchPressInputAction.Enable();
        }

        private void AddMoveInputActionListener()
        {
            _touchPressInputAction.started += OnTouchDown;
            _moveInputAction.performed += OnTouch;
            _touchPressInputAction.canceled += OnTouchUp;
        }

        private void OnTouchDown(InputAction.CallbackContext ctx)
        {
            if (IsInputDeviceNotTouchscreen(ctx)) return;

            SetStartTouchVector2();
            SetTouchVector2();
            _touchInputModel.OnTouchDown();
        }

        private void SetStartTouchVector2()
        {
            Vector2 _start_touch_vector2 = _moveInputAction.ReadValue<Vector2>();
            _touchInputModel.SetStartTouchVector2(_start_touch_vector2);
        }

        private void SetTouchVector2()
        {
            Vector2 _touch_vector2 = _moveInputAction.ReadValue<Vector2>();
            _touchInputModel.SetTouchVector2(_touch_vector2);
        }

        private void OnTouch(InputAction.CallbackContext ctx)
        {
            if (inputType != IControllerInputAction.InputType.touchScreen) return;

            SetTouchVector2();
            _touchInputModel.OnTouch();
        }

        private bool IsInputDeviceNotTouchscreen(InputAction.CallbackContext ctx)
        {
            InputDevice device = ctx.control.device;

            if (device is Touchscreen)
            {
                Debug.Log("The current input is Touchscreen.");
                inputType = IControllerInputAction.InputType.touchScreen;
                return false;
            }

            return true;
        }

        private void OnTouchUp(InputAction.CallbackContext ctx)
        {
            if (inputType != IControllerInputAction.InputType.touchScreen) return;
            
            _touchInputModel.ResetInputVector2ToZero();
            _touchInputModel.OnTouchUp();
        }

        /// <summary>
        /// The project has disabled Reload Domain, so Listeners need to be manually removed.
        /// </summary>
        public override void RemoveAllInputActionListener()
        {
            base.RemoveAllInputActionListener();

            _touchPressInputAction.started -= OnTouchDown;
            _moveInputAction.performed -= OnTouch;
            _touchPressInputAction.canceled -= OnTouchUp;

            Debug.Log(nameof(RemoveAllInputActionListener));
        }
    }
}
#endif