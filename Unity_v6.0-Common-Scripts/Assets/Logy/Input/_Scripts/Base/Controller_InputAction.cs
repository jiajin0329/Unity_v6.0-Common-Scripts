using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class Controller_InputAction : IController_InputAction
    {
        [SerializeField]
        protected InputActionAsset _inputActionAsset;
        protected InputAction _move_inputAction;
        [field: SerializeField]
        public IController_InputAction.Input_Type input_type { get; protected set; }
        private Input_Model _input_model;
        

        public bool is_inputActionAsset_notNull => _inputActionAsset != null;
        public bool is_move_inputAction_notNull => _move_inputAction != null;

        public void Set_Reference(Input_Model _input_model) { this._input_model = _input_model; }

        public virtual async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);

            Variable_Initialize();
            Add_move_inputAction_Listener();
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.VariableNull(_inputActionAsset, nameof(_inputActionAsset)))
            {
                _inputActionAsset = await UniTaskEX.AddressablesLoadAssetAsync<InputActionAsset>("InputSystem Actions", _cancellationToken);
            }
        }

        private void Variable_Initialize()
        {
            _inputActionAsset.FindActionMap("UI").Disable();
            _move_inputAction = _inputActionAsset.FindAction("Player/Move");
            _move_inputAction.Enable();
        }

        private void Add_move_inputAction_Listener()
        {
            _move_inputAction.started += OnInputDown;
            _move_inputAction.performed += OnInput;
            _move_inputAction.canceled += OnInputUp;
        }

        private void OnInputDown(InputAction.CallbackContext ctx)
        {
            if (Is_InputDevice_Not_Keyboard(ctx)) return;

            Set_input_vector2();
            _input_model.OnInputDown();
        }

        private bool Is_InputDevice_Not_Keyboard(InputAction.CallbackContext ctx)
        {
            InputDevice device = ctx.control.device;

            if (device is Keyboard)
            {
                Debug.Log("The current input is Keyboard.");
                input_type = IController_InputAction.Input_Type.Keyboard;
                return false;
            }

            return true;
        }

        private void Set_input_vector2()
        {
            Vector2 _input_vector2 = _move_inputAction.ReadValue<Vector2>();
            _input_model.Set_input_vector2(_input_vector2);
        }

        private void OnInput(InputAction.CallbackContext ctx)
        {
            if (input_type != IController_InputAction.Input_Type.Keyboard) return;

            Set_input_vector2();
            _input_model.OnInput();
        }

        private void OnInputUp(InputAction.CallbackContext ctx)
        {
            if (input_type != IController_InputAction.Input_Type.Keyboard) return;

            Set_input_vector2();
            _input_model.OnInputUp();
        }

        public virtual void Remove_All_inputAction_Listener()
        {
            _move_inputAction.started -= OnInputDown;
            _move_inputAction.performed -= OnInput;
            _move_inputAction.canceled -= OnInputUp;
        }
    }
}