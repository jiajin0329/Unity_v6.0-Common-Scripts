#if UNITY_WEBGL
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class Launcher_Input_Generic_TopDown : Launcher, IHas_Initialize_With_UniTask, IHas_Tick
    {
        [SerializeField]
        private Module_Input_Generic_TopDown _module_input_generic_topDown = new();
        protected override Module _module => _module_input_generic_topDown;

        public Launcher_Input_Generic_TopDown() : base(nameof(Launcher_Input_Generic_TopDown)) {}
    }

    [Serializable]
    public class Module_Input_Generic_TopDown : Module, IHas_Initialize_With_UniTask, IHas_Tick
    {
        [SerializeField]
        private Player_Input_Generic_Presenter _player_input = new();
        [SerializeField]
        private Rigidbody_Move _rigidbody_move = new();
        [SerializeField]
        private Player_StateMachine_TopDown _player_stateMachine = new();
        [SerializeField]
        private Player_View_TopDown_Presenter _player_view_presenter = new();
        [SerializeField]
        private CinemachineCamera _cinemachineCamera;

        public Module_Input_Generic_TopDown() : base(nameof(Module_Input_Generic_TopDown)) {}

        public override async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            await _player_input.Variable_Null_Handle(_cancellationToken);
            await _player_stateMachine.Variable_Null_Handle(_cancellationToken);
            await _rigidbody_move.Variable_Null_Handle(_cancellationToken);
            await _player_view_presenter.Variable_Null_Handle(_cancellationToken);
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await _player_input.Initialize_With_UniTask(_cancellationToken);
            await _rigidbody_move_Initialize(_cancellationToken);
            await _plyaer_stateMachine_Initialize_With_UniTask(_cancellationToken);
            await _player_view_topDown_Initialize_With_UniTask(_cancellationToken);
            _cinemachineCamera.Follow = _rigidbody_move.transform;
        }

        private async UniTask _rigidbody_move_Initialize(CancellationToken _cancellationToken)
        {
            _rigidbody_move.Set_Reference(_player_input.model.input_model);
            await _rigidbody_move.Initialize_With_UniTask(_cancellationToken);
        }

        private async UniTask _plyaer_stateMachine_Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            _player_stateMachine.Set_Reference(_rigidbody_move.move_model);
            await _player_stateMachine.Initialize_With_UniTask(_cancellationToken);
        }

        private async UniTask _player_view_topDown_Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            Player_View_TopDown_Presenter.Data _data = new()
            {
                parent = _rigidbody_move.transform,
                move_model = _rigidbody_move.move_model,
                stateMachine = _player_stateMachine.stateMachine,
            };

            _player_view_presenter.Set_Reference(_data);
            await _player_view_presenter.Initialize_With_UniTask(_cancellationToken);
        }

        protected override void Tick_Detail()
        {
            _rigidbody_move.Tick();
        }

        public override void Cancel()
        {
            //The project has disabled Reload Domain, so Listeners need to be manually removed.
            _player_input.model.controller.Remove_All_inputAction_Listener();
        }
    }
}
#endif