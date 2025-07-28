#if UNITY_WEBGL
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class Launcher_Input_Generic_TopDown : Launcher, IHas_Initialize_With_UniTask, IHas_Begin
    {
        [SerializeField] Core_Input_Generic_TopDown _core_input_generic_topDown;
        protected override Core _core => _core_input_generic_topDown;

        public Launcher_Input_Generic_TopDown() : base(nameof(Launcher_Input_Generic_TopDown)) {}
    }

    [Serializable]
    public class Core_Input_Generic_TopDown : Core, IHas_Begin
    {
        [SerializeField] private Player_Input_Generic _player_input;
        [SerializeField] private Player_StateMachine_TopDown _player_stateMachine;
        [SerializeField] private Player_View_TopDown_Presenter _player_view_presenter;

        public Core_Input_Generic_TopDown() : base(nameof(Core_Input_Generic_TopDown)) {}

        public override async UniTask Reset(CancellationToken _cancellationToken)
        {
            await _player_input.Reset(_cancellationToken);
            await _player_stateMachine.Reset(_cancellationToken);
            await _player_view_presenter.player_view.Variable_Null_Handle(_cancellationToken);
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await _player_input.Initialize_With_UniTask(_cancellationToken);

            await _plyaer_stateMachine_Initialize_With_UniTask(_cancellationToken);

            await _player_view_topDown_Initialize_With_UniTask(_cancellationToken);
        }

        private async UniTask _plyaer_stateMachine_Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            _player_stateMachine.Set_Reference(_player_input.model.input_model);
            await _player_stateMachine.Initialize_With_UniTask(_cancellationToken);
        }

        private async UniTask _player_view_topDown_Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            Player_View_TopDown_Presenter.Data _data = new()
            {
                input_model = _player_input.model.input_model,
                stateMachine = _player_stateMachine.stateMachine,
            };

            _player_view_presenter.Set_Reference(_data);
            await _player_view_presenter.Initialize_With_UniTask(_cancellationToken);
        }

        protected override void Begin_Detail()
        {
            _player_input.Begin();
        }

        public override void Cancel()
        {
            //The project has disabled Reload Domain, so Listeners need to be manually removed.
            _player_input.model.controller_inputAction_generic.Remove_All_inputAction_Listener();
        }
    }
}
#endif