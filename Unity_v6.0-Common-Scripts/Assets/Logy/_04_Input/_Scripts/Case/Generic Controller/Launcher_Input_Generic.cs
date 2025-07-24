using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class Launcher_Input_Generic : Launcher, IHas_Initialize_With_UniTask, IHas_Begin
    {
        [SerializeField] Core_Input_Generic _core_input_generic_topDown;
        protected override Core _core => _core_input_generic_topDown;
        
        public Launcher_Input_Generic() : base(nameof(Launcher_Input_Generic)) {}
    }

    [Serializable]
    public class Core_Input_Generic : Core, IHas_Begin
    {
        [SerializeField] private Player_Input_Generic _player_input;

        public Core_Input_Generic() : base(nameof(Core_Input_Generic)) { }

        public override async UniTask Reset(CancellationToken _cancellationToken)
        {
            await _player_input.model.controller_inputAction_generic.Variable_Null_Handle(_cancellationToken);
            await _player_input.model.virtualJoystick_view.Variable_Null_Handle(_cancellationToken);
            await _player_input.variable_viewer.Variable_Null_Handle(_cancellationToken);
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await _player_input.Initialize_With_UniTask(_cancellationToken);
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