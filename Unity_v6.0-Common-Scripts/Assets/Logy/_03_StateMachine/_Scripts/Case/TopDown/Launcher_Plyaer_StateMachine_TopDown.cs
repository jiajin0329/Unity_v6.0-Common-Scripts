using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class Launcher_Plyaer_StateMachine_TopDown : Launcher, IHas_Initialize_With_UniTask, IHas_Begin
    {
        [SerializeField] Core_Plyaer_StateMachine_TopDown _core_input_generic_topDown;
        protected override Core _core => _core_input_generic_topDown;
        
        public Launcher_Plyaer_StateMachine_TopDown() : base(nameof(Launcher_Plyaer_StateMachine_TopDown)) {}
    }

    [Serializable]
    public class Core_Plyaer_StateMachine_TopDown : Core, IHas_Begin
    {
        [SerializeField] private Player_Input_Generic _player_input;
        [SerializeField] private Plyaer_StateMachine_TopDown _plyaer_stateMachine;

        public Core_Plyaer_StateMachine_TopDown() : base(nameof(Core_Plyaer_StateMachine_TopDown)) { }

        public override async UniTask Reset(CancellationToken _cancellationToken)
        {
            await _player_input.model.controller_inputAction_generic.Variable_Null_Handle(_cancellationToken);
            await _player_input.model.virtualJoystick_view.Variable_Null_Handle(_cancellationToken);
            await _player_input.variable_viewer.Variable_Null_Handle(_cancellationToken);
            await _plyaer_stateMachine.variable_viewer.Variable_Null_Handle(_cancellationToken);
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await _player_input.Initialize_With_UniTask(_cancellationToken);

            await _plyaer_stateMachine_Initialize_With_UniTask(_cancellationToken);
        }

        private async UniTask _plyaer_stateMachine_Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            _plyaer_stateMachine.Set_Reference(_player_input.model.input_model);
            await _plyaer_stateMachine.Initialize_With_UniTask(_cancellationToken);
        }

        protected override void Begin_Detail()
        {
            _player_input.Begin();

            _plyaer_stateMachine.Begin();
        }

        public override void Cancel()
        {
            //The project has disabled Reload Domain, so Listeners need to be manually removed.
            _player_input.model.controller_inputAction_generic.Remove_All_inputAction_Listener();
        }
    }
}