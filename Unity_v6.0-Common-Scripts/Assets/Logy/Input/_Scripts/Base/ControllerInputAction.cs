using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class ControllerInputAction : IControllerInputAction
    {
        [SerializeField]
        protected InputActionAsset _inputActionAsset;
        protected InputAction _moveInputAction;
        [field: SerializeField]
        public IControllerInputAction.InputType inputType { get; protected set; }
        private InputModel _inputModel;

        public bool isInputActionAssetNotNull => _inputActionAsset != null;
        public bool isMoveInputActionNotNull => _moveInputAction != null;

        public void SetReference(InputModel _inputModel) { this._inputModel = _inputModel; }

        public virtual async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await VariableNullHandle(_cancellationToken);

            VariableInitialize();
            AddMoveInputActionListener();
        }

        public async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            if (Is.VariableNull(_inputActionAsset, nameof(_inputActionAsset)))
            {
                _inputActionAsset = await UniTaskEX.AddressablesLoadAssetAsync<InputActionAsset>("InputSystem-Actions", _cancellationToken);
            }
        }

        private void VariableInitialize()
        {
            _inputActionAsset.FindActionMap("UI").Disable();
            _moveInputAction = _inputActionAsset.FindAction("Player/Move");
            _moveInputAction.Enable();
        }

        private void AddMoveInputActionListener()
        {
            _moveInputAction.started += OnInputDown;
            _moveInputAction.performed += OnInput;
            _moveInputAction.canceled += OnInputUp;
        }

        private void OnInputDown(InputAction.CallbackContext ctx)
        {
            if (IsInputDeviceNotKeyboard(ctx)) return;

            SetInputVector2();
            _inputModel.OnInputDown();
        }

        private bool IsInputDeviceNotKeyboard(InputAction.CallbackContext ctx)
        {
            InputDevice device = ctx.control.device;

            if (device is Keyboard)
            {
                Debug.Log("The current input is Keyboard.");
                inputType = IControllerInputAction.InputType.keyboard;
                return false;
            }

            return true;
        }

        private void SetInputVector2()
        {
            Vector2 _input_vector2 = _moveInputAction.ReadValue<Vector2>();
            _inputModel.SetInputVector2(_input_vector2);
        }

        private void OnInput(InputAction.CallbackContext ctx)
        {
            if (inputType != IControllerInputAction.InputType.keyboard) return;

            SetInputVector2();
            _inputModel.OnInput();
        }

        private void OnInputUp(InputAction.CallbackContext ctx)
        {
            if (inputType != IControllerInputAction.InputType.keyboard) return;

            SetInputVector2();
            _inputModel.OnInputUp();
        }

        public virtual void RemoveAllInputActionListener()
        {
            _moveInputAction.started -= OnInputDown;
            _moveInputAction.performed -= OnInput;
            _moveInputAction.canceled -= OnInputUp;
        }
    }
}