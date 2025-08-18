#if UNITY_WEBGL && DEBUG
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class InputGenericVariableViewer : VariableViewer
    {
        private VariableUI _inputTypeVariableUi;
        private VariableUI _startTouchVector2VariableUi;
        private VariableUI _touchVector2VariableUi;
        private VariableUI _inputDonwVariableUi;
        private VariableUI _inputVariableUi;
        private VariableUI _inputUpVariableUi;
        private VariableUI _inputVector2VariableUi;
        private VariableUI _inputMagnitudeVariableUi;
        private VariableUI _inputRadianVariableUi;

        [NonSerialized]
        public IPlayerInputGenericModel _model;

        public void SetReference(IPlayerInputGenericModel _model) { this._model = _model; }

        public override async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await base.InitializeWithUniTask(_cancellationToken);

            InitializeVariableText();

            AddActionListeners();
        }

        private void InitializeVariableText()
        {
            // initialize the variable text
            _inputTypeVariableUi.Initialize($"{nameof(ControllerInputAction.inputType)} : ", _variableText, false);

            _startTouchVector2VariableUi.Initialize($"{nameof(TouchInputModel.startTouchVector2)} : ", _variableText);
            _touchVector2VariableUi.Initialize($"{nameof(TouchInputModel.touchVector2)} : ", _variableText);

            _inputDonwVariableUi.Initialize($"{nameof(InputModel.inputDown)} : ", _variableText);
            _inputVariableUi.Initialize($"{nameof(InputModel.input)} : ", _variableText);
            _inputUpVariableUi.Initialize($"{nameof(InputModel.inputUp)} : ", _variableText);
            _inputVector2VariableUi.Initialize($"{nameof(InputModel.inputVector2)} : ", _variableText);
            _inputMagnitudeVariableUi.Initialize($"inputMagnitude : ", _variableText);
            _inputRadianVariableUi.Initialize($"{nameof(InputModel.inputRadian)} : ", _variableText);
        }

        private void AddActionListeners()
        {
            _model.inputModel.InputDownAction += UpdateVariableUi;
            _model.inputModel.InputAction += UpdateVariableUi;
            _model.inputModel.InputUpAction += UpdateVariableUi;
        }

        private void UpdateVariableUi()
        {
            _inputTypeVariableUi.UpdateText(_model.controller.inputType.ToString());

            _startTouchVector2VariableUi.UpdateText(_model.touchInputModel.startTouchVector2.ToString());
            _touchVector2VariableUi.UpdateText(_model.touchInputModel.touchVector2.ToString());

            _inputDonwVariableUi.UpdateText(_model.inputModel.inputDown.ToString());
            _inputVariableUi.UpdateText(_model.inputModel.input.ToString());
            _inputUpVariableUi.UpdateText(_model.inputModel.inputUp.ToString());
            _inputVector2VariableUi.UpdateText(_model.inputModel.inputVector2.ToString());
            _inputMagnitudeVariableUi.UpdateText(_model.inputModel.inputVector2.magnitude.ToString());
            _inputRadianVariableUi.UpdateText(_model.inputModel.inputRadian.ToString());
        }
    }
}
# endif