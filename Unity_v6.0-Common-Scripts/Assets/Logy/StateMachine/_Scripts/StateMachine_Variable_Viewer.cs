#if DEBUG
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class StateMachine_Variable_Viewer : VariableViewer
    {
        private VariableUI _player_state_variable_ui;

        private IStateMachine _stateMachine;

        public void Set_Reference(IStateMachine _stateMachine) { this._stateMachine = _stateMachine; }

        public override async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await base.InitializeWithUniTask(_cancellationToken);

            _player_state_variable_ui.Initialize("player current state : ", _variableText);

            _stateMachine.Tick_Action += Update_player_state_variable_ui;
        }

        private void Update_player_state_variable_ui()
        {
            _player_state_variable_ui.UpdateText(_stateMachine.current_state_name);
        }
    }
}
# endif