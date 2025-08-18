#if UNITY_WEBGL
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    public class LauncherInputGenericTopDown : Launcher, IHasInitializeWithUniTask, IHasTick
    {
        [SerializeField]
        private ModuleInputGenericTopDown _moduleInputGenericTopDown = new();
        protected override Module _module => _moduleInputGenericTopDown;

        public LauncherInputGenericTopDown() : base(nameof(LauncherInputGenericTopDown)) {}
    }

    [Serializable]
    public class ModuleInputGenericTopDown : Module, IHasInitializeWithUniTask, IHasTick
    {
        [SerializeField]
        private PlayerInputGenericPresenter _playerInput = new();
        [SerializeField]
        private Rigidbody_Move _rigidbodyMove = new();
        [SerializeField]
        private Player_StateMachine_TopDown_Presenter _playerStateMachine = new();
        [SerializeField]
        private PlayerViewTopDownPresenter _playerView = new();
        [SerializeField]
        private CinemachineCamera _cinemachineCamera;
        [SerializeField]
        private ParticleSystem _ambientGlowsFx;
        [SerializeField]
        private UI _ui = new();
        

        public ModuleInputGenericTopDown() : base(nameof(ModuleInputGenericTopDown)) { }

        public override async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            await _playerInput.VariableNullHandle(_cancellationToken);
            await _playerStateMachine.Variable_Null_Handle(_cancellationToken);
            await _rigidbodyMove.Variable_Null_Handle(_cancellationToken);
            await _playerView.VariableNullHandle(_cancellationToken);
        }

        protected override async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            await _playerInput.InitializeWithUniTask(_cancellationToken);
            await RigidbodyMoveInitialize(_cancellationToken);
            await PlyaerStateMachineInitializeWithUniTask(_cancellationToken);
            await PlayerViewTopDownInitializeWithUniTask(_cancellationToken);
            _cinemachineCamera.Follow = _rigidbodyMove.transform;
            UnityEngine.Object.Instantiate(_ambientGlowsFx, _rigidbodyMove.transform);
            _ui.Initialize();
        }

        private async UniTask RigidbodyMoveInitialize(CancellationToken _cancellationToken)
        {
            _rigidbodyMove.Set_Reference(_playerInput.model.inputModel);
            await _rigidbodyMove.InitializeWithUniTask(_cancellationToken);
        }

        private async UniTask PlyaerStateMachineInitializeWithUniTask(CancellationToken _cancellationToken)
        {
            _playerStateMachine.Set_Reference(_rigidbodyMove.move_model);
            await _playerStateMachine.InitializeWithUniTask(_cancellationToken);
        }

        private async UniTask PlayerViewTopDownInitializeWithUniTask(CancellationToken _cancellationToken)
        {
            PlayerViewTopDownPresenter.Data _data = new()
            {
                parent = _rigidbodyMove.transform,
                moveModel = _rigidbodyMove.move_model,
                stateMachine = _playerStateMachine.stateMachine,
            };

            _playerView.SetReference(_data);
            await _playerView.InitializeWithUniTask(_cancellationToken);
        }

        protected override void TickDetail()
        {
            _rigidbodyMove.Tick();
            _playerStateMachine.Tick();
        }

        public override void Cancel()
        {
            //The project has disabled Reload Domain, so Listeners need to be manually removed.
            _playerInput.model.controller.RemoveAllInputActionListener();
        }
    }
}
#endif