using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_Input_Generic : Process, IHas_Initialize_With_UniTask, IHas_Begin
    {
        public IInput_Generic_Model model => _model;
        [field: SerializeField] public Input_Generic_Model _model { get; private set; } = new();
        [field: SerializeField] public Input_Generic_Presenter presenter { get; private set; } = new();
#if DEBUG
        [field: SerializeField] public Input_Generic_Variable_Viewer variable_viewer { get; private set; } = new();
#endif
        public Player_Input_Generic() : base(nameof(Player_Input_Generic)) {}

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            await _model.controller_inputAction_generic.Variable_Null_Handle(_cancellationToken);
            await _model.virtualJoystick_view.Variable_Null_Handle(_cancellationToken);

#if DEBUG
            await variable_viewer.Variable_Null_Handle(_cancellationToken);
#endif
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            presenter.Set_Reference(_model);

            await _model.Initialize_With_UniTask(_cancellationToken);

            presenter.Initialize();

#if DEBUG
            variable_viewer.Set_Reference(_model);
            await variable_viewer.Initialize_With_UniTask(_cancellationToken);
#endif
        }

        protected override void Begin_Detail()
        {
            _model.Begin();
        }
    }
}