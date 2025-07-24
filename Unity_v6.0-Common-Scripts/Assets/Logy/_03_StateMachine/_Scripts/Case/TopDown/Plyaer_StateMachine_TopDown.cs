using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Plyaer_StateMachine_TopDown : Process, IHas_Begin
    {
        [field: SerializeField] public StateMachine_Model_TopDown stateMachine { get; private set; } = Factory_StateMachine_Model_TopDown.New(Factory_StateMachine_Model_TopDown.Type.player);
        [SerializeField] private Plyaer_StateMachine_TopDown_Presenter _presenter = new();
#if DEBUG
        [field: SerializeField] public StateMachine_Variable_Viewer variable_viewer { get; private set; } = new();
#endif

        public Plyaer_StateMachine_TopDown() : base(nameof(Plyaer_StateMachine_TopDown)) {}

        public void Set_Reference(Input_Model _input_model)
        {
            Plyaer_StateMachine_TopDown_Presenter.Data _data = new()
            {
                stateMachine_model = stateMachine,
                input_model = _input_model,
            };

            _presenter.Set_Reference(_data);
            variable_viewer.Set_Reference(stateMachine);
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            stateMachine.Initialize();
            _presenter.Initialize();
            await variable_viewer.Initialize_With_UniTask(_cancellationToken);
        }

        protected override void Begin_Detail()
        {
            stateMachine.Begin();
        }
    }
}