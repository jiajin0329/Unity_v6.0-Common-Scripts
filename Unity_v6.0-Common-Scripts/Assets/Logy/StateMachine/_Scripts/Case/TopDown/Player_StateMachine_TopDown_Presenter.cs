using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_StateMachine_TopDown_Presenter : Process, IHas_Initialize_With_UniTask, IHas_Tick
    {
        [field: SerializeField]
        private StateMachine_TopDown _stateMachine = Factory_StateMachine_TopDown.New(Factory_StateMachine_TopDown.Type.player);
        public IStateMachine_TopDown stateMachine => _stateMachine;
#if DEBUG
        [field: SerializeField]
        private StateMachine_Variable_Viewer _variable_viewer = new();
#endif

        public Player_StateMachine_TopDown_Presenter() : base(nameof(Player_StateMachine_TopDown_Presenter)) {}

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
#if DEBUG
            await _variable_viewer.Variable_Null_Handle(_cancellationToken);
#endif
            await UniTask.CompletedTask;
        }

        public void Set_Reference(IMove_Model _move_model)
        {
            _stateMachine.Set_Reference(_move_model);

#if DEBUG
            _variable_viewer.Set_Reference(_stateMachine);
#endif  
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            _stateMachine.Initialize();

#if DEBUG
            await _variable_viewer.Initialize_With_UniTask(_cancellationToken);
#endif
            await UniTask.CompletedTask;
        }

        protected override void Tick_Detail()
        {
            _stateMachine.Tick();
        }
    }
}