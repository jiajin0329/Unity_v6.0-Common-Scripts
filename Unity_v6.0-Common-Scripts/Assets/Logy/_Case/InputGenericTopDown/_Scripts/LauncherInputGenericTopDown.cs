#if UNITY_WEBGL
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class LauncherInputGenericTopDown : Launcher, IHas_Initialize_With_UniTask, IHas_Tick
    {
        [SerializeField]
        private ModuleInputGenericTopDown _moduleInputGenericTopDown = new();
        protected override Module _module => _moduleInputGenericTopDown;

        public LauncherInputGenericTopDown() : base(nameof(LauncherInputGenericTopDown)) {}
    }

    [Serializable]
    public class ModuleInputGenericTopDown : Module, IHas_Initialize_With_UniTask, IHas_Tick
    {
        [SerializeField]
        private Player_Input_Generic_Presenter _playerInput = new();
        [SerializeField]
        private Rigidbody_Move _rigidbodyMove = new();
        [SerializeField]
        private Player_StateMachine_TopDown_Presenter _playerStateMachine = new();
        [SerializeField]
        private Player_View_TopDown_Presenter _playerView = new();
        [SerializeField]
        private CinemachineCamera _cinemachineCamera;
        [SerializeField]
        private ParticleSystem _ambientGlowsFx;
        

        public ModuleInputGenericTopDown() : base(nameof(ModuleInputGenericTopDown)) { }

        public override async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            await _playerInput.Variable_Null_Handle(_cancellationToken);
            await _playerStateMachine.Variable_Null_Handle(_cancellationToken);
            await _rigidbodyMove.Variable_Null_Handle(_cancellationToken);
            await _playerView.Variable_Null_Handle(_cancellationToken);
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await _playerInput.Initialize_With_UniTask(_cancellationToken);
            await RigidbodyMoveInitialize(_cancellationToken);
            await PlyaerStateMachineInitializeWithUniTask(_cancellationToken);
            await PlayerViewTopDownInitializeWithUniTask(_cancellationToken);
            _cinemachineCamera.Follow = _rigidbodyMove.transform;

            UnityEngine.Object.Instantiate(_ambientGlowsFx, _rigidbodyMove.transform);
        }

        private async UniTask RigidbodyMoveInitialize(CancellationToken _cancellationToken)
        {
            _rigidbodyMove.Set_Reference(_playerInput.model.input_model);
            await _rigidbodyMove.Initialize_With_UniTask(_cancellationToken);
        }

        private async UniTask PlyaerStateMachineInitializeWithUniTask(CancellationToken _cancellationToken)
        {
            _playerStateMachine.Set_Reference(_rigidbodyMove.move_model);
            await _playerStateMachine.Initialize_With_UniTask(_cancellationToken);
        }

        private async UniTask PlayerViewTopDownInitializeWithUniTask(CancellationToken _cancellationToken)
        {
            Player_View_TopDown_Presenter.Data _data = new()
            {
                parent = _rigidbodyMove.transform,
                move_model = _rigidbodyMove.move_model,
                stateMachine = _playerStateMachine.stateMachine,
            };

            _playerView.Set_Reference(_data);
            await _playerView.Initialize_With_UniTask(_cancellationToken);
        }

        protected override void Tick_Detail()
        {
            _rigidbodyMove.Tick();
            _playerStateMachine.Tick();
        }

        public override void Cancel()
        {
            //The project has disabled Reload Domain, so Listeners need to be manually removed.
            _playerInput.model.controller.Remove_All_inputAction_Listener();
        }
    }
}
#endif