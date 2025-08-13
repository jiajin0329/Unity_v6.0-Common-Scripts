using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_StateMachine_TopDown : Process, IHas_Initialize_With_UniTask
    {
        [field: SerializeField] public StateMachine_TopDown stateMachine { get; private set; } = Factory_StateMachine_TopDown.New(Factory_StateMachine_TopDown.Type.player);
        [SerializeField] private Player_StateMachine_TopDown_Presenter _presenter = new();
#if DEBUG
        [field: SerializeField] public StateMachine_Variable_Viewer variable_viewer { get; private set; } = new();
#endif

        public Player_StateMachine_TopDown() : base(nameof(Player_StateMachine_TopDown)) {}

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
#if DEBUG
            await variable_viewer.Variable_Null_Handle(_cancellationToken);
#else
            await UniTask.CompletedTask;
#endif
        }

        public void Set_Reference(IMove_Model _move_model)
        {
            stateMachine.velocity_model = _move_model;

            Player_StateMachine_TopDown_Presenter.Data _data = new()
            {
                stateMachine = stateMachine,
                move_model = _move_model,
            };

            _presenter.Set_Reference(_data);

#if DEBUG
            variable_viewer.Set_Reference(stateMachine);
#endif  
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            stateMachine.Initialize();
            _presenter.Initialize();

#if DEBUG
            await variable_viewer.Initialize_With_UniTask(_cancellationToken);
#else
            await UniTask.CompletedTask;
#endif
        }
    }
}