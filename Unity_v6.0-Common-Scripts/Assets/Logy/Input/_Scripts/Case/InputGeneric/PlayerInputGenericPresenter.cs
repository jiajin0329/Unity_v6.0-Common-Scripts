using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class PlayerInputGenericPresenter : Process, IHasInitializeWithUniTask, IHasTick
    {
        [SerializeField]
        private PlayerInputGenericModel _model = new();
        public IPlayerInputGenericModel model => _model;
        [field: SerializeField]
        public VirtualJoystickView virtualJoystickView { get; private set; } = new();
#if DEBUG
        [field: SerializeField]
        public InputGenericVariableViewer variableViewer { get; private set; } = new();
#endif

        public PlayerInputGenericPresenter() : base(nameof(PlayerInputGenericPresenter)) {}

        public async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            await _model.VariableNullHandle(_cancellationToken);
            await virtualJoystickView.VariableNullHandle(_cancellationToken);
#if DEBUG
            await variableViewer.VariableNullHandle(_cancellationToken);
#endif
        }

        protected override async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            await _model.InitializeWithUniTask(_cancellationToken);

            virtualJoystickView.SetReference(_model.touchInputModel, _model.inputModel);
            await virtualJoystickView.InitializeWithUniTask(_cancellationToken);

            AddTouchListener();

#if DEBUG
            variableViewer.SetReference(_model);
            await variableViewer.InitializeWithUniTask(_cancellationToken);
#endif
        }

        private void AddTouchListener()
        {
            AddOnTouchDownListener();
            AddOnTouchListener();
            AddOnTouchUpListener();
        }

        private void AddOnTouchDownListener()
        {
            _model.touchInputModel.TouchDownAction += virtualJoystickView.ShowUi;
            _model.touchInputModel.TouchDownAction += virtualJoystickView.Tick;
        }

        private void AddOnTouchListener()
        {
            _model.touchInputModel.TouchAction += virtualJoystickView.Tick;
        }

        private void AddOnTouchUpListener()
        {
            _model.touchInputModel.TouchUpAction += virtualJoystickView.HideUi;
            _model.touchInputModel.TouchUpAction += virtualJoystickView.Tick;
        }
    }
}