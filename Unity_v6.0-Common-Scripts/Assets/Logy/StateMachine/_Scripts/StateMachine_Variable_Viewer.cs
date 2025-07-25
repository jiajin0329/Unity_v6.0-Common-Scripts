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

        private IStateMachine_Model _stateMachine;

        public StateMachine_Variable_Viewer() : base(nameof(StateMachine_Variable_Viewer)) {}

        public void Set_Reference(IStateMachine_Model _stateMachine) { this._stateMachine = _stateMachine; }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await base.Initialize_Detail_With_UniTask(_cancellationToken);

            _player_state_variable_ui.Initialize("player current state : ", _variable_text);

            _stateMachine.Get_current_state_index_Action += Update_player_state_variable_ui;
        }

        private void Update_player_state_variable_ui(byte _current_state_index)
        {
            string _current_state_name = _stateMachine.states[_current_state_index].name;
            _player_state_variable_ui.Update_Text(_current_state_name);
        }
    }
}
# endif