using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class PlayerStateMachineTopDownPresenter : Process, IHasInitializeWithUniTask, IHasTick
    {
        [field: SerializeField]
        private StateMachineTopDown _stateMachine = FactoryStateMachineTopDown.New(FactoryStateMachineTopDown.Type.player);
        public IStateMachineTopDown stateMachine => _stateMachine;
#if DEBUG
        [field: SerializeField]
        private StateMachineVariableViewer _variableViewer = new();
#endif

        public PlayerStateMachineTopDownPresenter() : base(nameof(PlayerStateMachineTopDownPresenter)) {}

        public async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
#if DEBUG
            await _variableViewer.VariableNullHandle(_cancellationToken);
#endif
            await UniTask.CompletedTask;
        }

        public void SetReference(IMoveModel _move_model)
        {
            _stateMachine.SetReference(_move_model);
#if DEBUG
            _variableViewer.SetReference(_stateMachine);
#endif
        }

        protected override async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            _stateMachine.Initialize();
#if DEBUG
            await _variableViewer.InitializeWithUniTask(_cancellationToken);
#endif
            await UniTask.CompletedTask;
        }

        protected override void TickDetail()
        {
            _stateMachine.Tick();
        }
    }
}