#if DEBUG
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class StateMachine_Variable_Viewer : Variable_Viewer
    {
        private Variable_UI _player_state_variable_ui;

        private IStateMachine _stateMachine;

        public void Set_Reference(IStateMachine _stateMachine) { this._stateMachine = _stateMachine; }

        public override async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await base.Initialize_With_UniTask(_cancellationToken);

            _player_state_variable_ui.Initialize("player current state : ", _variable_text);

            _stateMachine.Tick_Action += Update_player_state_variable_ui;
        }

        private void Update_player_state_variable_ui()
        {
            _player_state_variable_ui.Update_Text(_stateMachine.current_state_name);
        }
    }
}
# endif