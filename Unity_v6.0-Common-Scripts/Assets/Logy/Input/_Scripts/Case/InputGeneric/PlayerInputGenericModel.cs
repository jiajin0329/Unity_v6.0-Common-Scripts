using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class PlayerInputGenericModel : IPlayerInputGenericModel
    {
        [field: SerializeField]
        private ControllerInputActionGeneric _controllerInputActionGeneric = new();
        public IControllerInputAction controller => _controllerInputActionGeneric;
        [field: SerializeField]
        private InputModel _inputModel = new();
        public IInputModel inputModel => _inputModel;
        [field: SerializeField]
        private TouchInputModel _touchInputModel = new();
        public ITouchInputModel touchInputModel => _touchInputModel;

        public async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            await _controllerInputActionGeneric.VariableNullHandle(_cancellationToken);
        }

        public async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            _inputModel.Initialize();

            _touchInputModel.SetReference(_inputModel);
            _touchInputModel.Initialize();

            _controllerInputActionGeneric.SetReference(_touchInputModel, _inputModel);
            await _controllerInputActionGeneric.InitializeWithUniTask(_cancellationToken);
        }
    }
}