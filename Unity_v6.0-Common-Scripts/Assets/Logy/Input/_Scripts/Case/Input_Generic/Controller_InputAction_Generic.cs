#if UNITY_WEBGL
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Controller_InputAction_Generic : Controller_InputAction
    {
        private InputAction _touchPress_inputAction;
        private Vector2 _start_touch_vector2;
        [SerializeField] private Updater _touch_updater;

        public event UnityAction<Vector2> Get_start_touch_vector2_Action;
        public event UnityAction<Vector2> Get_touch_vector2_Action;
        public event UnityAction TouchDown_Action;
        public event UnityAction Touch_Action;
        public event UnityAction TouchUp_Action;

        public bool is_touchPress_inputAction_notNull => _touchPress_inputAction != null;

        public override async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await base.Initialize_With_UniTask(_cancellationToken);

            Variable_Initialize();

            _start_touch_vector2 = Vector2.zero;

            _touch_updater = new(nameof(Controller_InputAction_Generic), _cancellationToken) { delay_ms = 16 };
            _touch_updater.Initialize();
            _touch_updater.Update_Action += Set_touch_vector2;
            _touch_updater.Update_Action += Update_Touch_Action;

            Get_start_touch_vector2_Action = null;
            Get_touch_vector2_Action = null;
            TouchDown_Action = null;
            Touch_Action = null;
            TouchUp_Action = null;

            Add_move_inputAction_Listener();
        }

        private void Variable_Initialize()
        {
            _touchPress_inputAction = _inputActionAsset.FindAction("Player/TouchPress");
            _touchPress_inputAction.Enable();
        }

        private void Update_Touch_Action()
        {
            TouchDown_Action?.Invoke();
        }

        private void Add_move_inputAction_Listener()
        {
            _touchPress_inputAction.started += OnTouchDown;
            _touchPress_inputAction.canceled += OnTouchUp;
        }

        public override void Begin()
        {
            base.Begin();

            Get_start_touch_vector2_Action?.Invoke(Vector2.zero);
            Get_touch_vector2_Action?.Invoke(Vector2.zero);
        }

        private void OnTouchDown(InputAction.CallbackContext ctx)
        {
            Set_start_touch_vector2();

            TouchDown_Action?.Invoke();

            OnTouch(ctx);
        }

        private void Set_start_touch_vector2()
        {
            _start_touch_vector2 = _move_inputAction.ReadValue<Vector2>();
            Get_start_touch_vector2_Action?.Invoke(_start_touch_vector2);
        }

        private void OnTouch(InputAction.CallbackContext ctx)
        {
            if (Is_InputDevice_Not_Touchscreen(ctx)) return;

            Set_touch_vector2();

            _touch_updater.Start_Update();

            Touch_Action?.Invoke();
        }

        private bool Is_InputDevice_Not_Touchscreen(InputAction.CallbackContext ctx)
        {
            InputDevice device = ctx.control.device;

            if (device is Touchscreen)
            {
                Debug.Log("The current input is Touchscreen.");
                Set_input_type(Input_Type.Touchscreen);
                return false;
            }

            return true;
        }

        private void Set_touch_vector2()
        {
            Get_touch_vector2_Action?.Invoke(_move_inputAction.ReadValue<Vector2>());
        }

        private void OnTouchUp(InputAction.CallbackContext ctx)
        {
            Reset_input_vector2_To_Zero();

            _touch_updater.Stop_Update();

            TouchUp_Action?.Invoke();
        }

        private void Reset_input_vector2_To_Zero()
        {
            Get_touch_vector2_Action?.Invoke(_start_touch_vector2);
        }

        /// <summary>
        /// The project has disabled Reload Domain, so Listeners need to be manually removed.
        /// </summary>
        public override void Remove_All_inputAction_Listener()
        {
            base.Remove_All_inputAction_Listener();

            _touchPress_inputAction.started -= OnTouchDown;
            _touchPress_inputAction.canceled -= OnTouchUp;

            Debug.Log(nameof(Remove_All_inputAction_Listener));
        }
    }
}
#endif