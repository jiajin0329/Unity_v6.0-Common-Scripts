#if DEBUG
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class StateMachineVariableViewer : VariableViewer
    {
        private VariableUI _playerStateMachineVariableUi;

        private IStateMachine _stateMachine;

        public void SetReference(IStateMachine _stateMachine) { this._stateMachine = _stateMachine; }

        public override async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await base.InitializeWithUniTask(_cancellationToken);

            _playerStateMachineVariableUi.Initialize("player current state : ", _variableText);

            _stateMachine.TickAction += UpdatePlayerStateMachineVariable_ui;
        }

        private void UpdatePlayerStateMachineVariable_ui()
        {
            _playerStateMachineVariableUi.UpdateText(_stateMachine.currentStateName);
        }
    }
}
# endif