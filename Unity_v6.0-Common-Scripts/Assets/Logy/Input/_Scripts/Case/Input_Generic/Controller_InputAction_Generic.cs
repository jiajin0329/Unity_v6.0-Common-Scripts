#if UNITY_WEBGL
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Controller_InputAction_Generic : Controller_InputAction
    {
        private InputAction _touchPress_inputAction;
        private Touch_Input_Model _touch_input_model;

        public bool is_touchPress_inputAction_notNull => _touchPress_inputAction != null;

        public void Set_Reference(Touch_Input_Model touch, Input_Model input)
        {
            _touch_input_model = touch;
            Set_Reference(input);
        }

        public override async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await base.Initialize_With_UniTask(_cancellationToken);

            Variable_Initialize();
            Add_move_inputAction_Listener();
        }

        private void Variable_Initialize()
        {
            _touchPress_inputAction = _inputActionAsset.FindAction("Player/TouchPress");
            _touchPress_inputAction.Enable();
        }

        private void Add_move_inputAction_Listener()
        {
            _touchPress_inputAction.started += OnTouchDown;
            _move_inputAction.performed += OnTouch;
            _touchPress_inputAction.canceled += OnTouchUp;
        }

        private void OnTouchDown(InputAction.CallbackContext ctx)
        {
            if (Is_InputDevice_Not_Touchscreen(ctx)) return;

            Set_start_touch_vector2();
            Set_touch_vector2();
            _touch_input_model.OnTouchDown();
        }

        private void Set_start_touch_vector2()
        {
            Vector2 _start_touch_vector2 = _move_inputAction.ReadValue<Vector2>();
            _touch_input_model.Set_start_touch_vector2(_start_touch_vector2);
        }

        private void Set_touch_vector2()
        {
            Vector2 _touch_vector2 = _move_inputAction.ReadValue<Vector2>();
            _touch_input_model.Set_touch_vector2(_touch_vector2);
        }

        private void OnTouch(InputAction.CallbackContext ctx)
        {
            if (input_type != IController_InputAction.Input_Type.Touchscreen) return;

            Set_touch_vector2();
            _touch_input_model.OnTouch();
        }

        private bool Is_InputDevice_Not_Touchscreen(InputAction.CallbackContext ctx)
        {
            InputDevice device = ctx.control.device;

            if (device is Touchscreen)
            {
                Debug.Log("The current input is Touchscreen.");
                input_type = IController_InputAction.Input_Type.Touchscreen;
                return false;
            }

            return true;
        }

        private void OnTouchUp(InputAction.CallbackContext ctx)
        {
            if (input_type != IController_InputAction.Input_Type.Touchscreen) return;
            
            _touch_input_model.Reset_input_vector2_To_Zero();
            _touch_input_model.OnTouchUp();
        }

        /// <summary>
        /// The project has disabled Reload Domain, so Listeners need to be manually removed.
        /// </summary>
        public override void Remove_All_inputAction_Listener()
        {
            base.Remove_All_inputAction_Listener();

            _touchPress_inputAction.started -= OnTouchDown;
            _move_inputAction.performed -= OnTouch;
            _touchPress_inputAction.canceled -= OnTouchUp;

            Debug.Log(nameof(Remove_All_inputAction_Listener));
        }
    }
}
#endif