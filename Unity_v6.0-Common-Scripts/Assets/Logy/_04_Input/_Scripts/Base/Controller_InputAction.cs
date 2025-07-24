using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Controller_InputAction : Process, IHas_Begin
    {
        [SerializeField] protected InputActionAsset _inputActionAsset;
        protected InputAction _move_inputAction;
        [SerializeField] private Updater _input_updater;
        public Input_Type input_type { get; protected set; }
        public enum Input_Type
        {
            Keyboard,
            Touchscreen
        }

        public event UnityAction<Input_Type> Get_input_type_Action;
        public event UnityAction<Vector2> Get_input_vector2_Action;
        public event UnityAction InputDown_Action;
        public event UnityAction Input_Action;
        public event UnityAction InputUp_Action;

        public bool is_inputActionAsset_notNull => _inputActionAsset != null;
        public bool is_move_inputAction_notNull => _move_inputAction != null;

        public Controller_InputAction(string _name) : base(_name) {}

        protected async override UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);

            Variable_Initialize();

            _input_updater = new(nameof(Controller_InputAction), _cancellationToken) { delay_ms = 16 };
            _input_updater.Initialize();
            _input_updater.Update_Action += Set_input_vector2;
            _input_updater.Update_Action += Update_Input_Action;

            Get_input_type_Action = null;
            Get_input_vector2_Action = null;
            InputDown_Action = null;
            Input_Action = null;
            InputUp_Action = null;

            Add_move_inputAction_Listener();
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.Variable_Null(_inputActionAsset, nameof(_inputActionAsset)))
            {
                _inputActionAsset = await UniTaskEX.Addressables_LoadAssetAsync<InputActionAsset>("InputSystem Actions", _cancellationToken);
            }
        }

        private void Variable_Initialize()
        {
            _inputActionAsset.FindActionMap("UI").Disable();
            _move_inputAction = _inputActionAsset.FindAction("Player/Move");
        }

        private void Update_Input_Action()
        {
            Input_Action?.Invoke();
        }

        private void Add_move_inputAction_Listener()
        {
            _move_inputAction.started += OnInputDown;
            _move_inputAction.canceled += OnInputUp;
        }

        protected override void Begin_Detail()
        {
            Get_input_type_Action?.Invoke(input_type);
            Get_input_vector2_Action?.Invoke(Vector2.zero);
        }

        protected void OnInputDown(InputAction.CallbackContext ctx)
        {
            if (Is_InputDevice_Not_Keyboard(ctx)) return;

            Set_input_vector2();

            InputDown_Action?.Invoke();

            OnInput(ctx);
        }

        private bool Is_InputDevice_Not_Keyboard(InputAction.CallbackContext ctx)
        {
            InputDevice device = ctx.control.device;

            if (device is Keyboard)
            {
                Debug.Log("The current input is Keyboard.");
                Set_input_type(Input_Type.Keyboard);
                return false;
            }

            return true;
        }

        protected void Set_input_type(Input_Type _set)
        {
            input_type = _set;
            Get_input_type_Action?.Invoke(input_type);
        }

        private void Set_input_vector2()
        {
            Get_input_vector2_Action?.Invoke(_move_inputAction.ReadValue<Vector2>());
        }

        protected void OnInput(InputAction.CallbackContext ctx)
        {
            if (Is_InputDevice_Not_Keyboard(ctx)) return;

            Set_input_vector2();

            _input_updater.Start_Update();
        }

        protected void OnInputUp(InputAction.CallbackContext ctx)
        {
            if (Is_InputDevice_Not_Keyboard(ctx)) return;

            Set_input_vector2();

            _input_updater.Stop_Update();

            InputUp_Action?.Invoke();
        }

        public virtual void Remove_All_inputAction_Listener()
        {
            _move_inputAction.started -= OnInputDown;
            _move_inputAction.canceled -= OnInputUp;
        }
    }
}