using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Input_Generic_Model
    {
        [field: SerializeField] public Controller_InputAction_Generic controller_inputAction_generic { get; private set; } = new();
        [field: SerializeField] public Input_Model input_model { get; private set; } = new();
        [field: SerializeField] public Touch_Input_Model touch_input_model { get; private set; } = new();
        [field: SerializeField] public VirtualJoystick_View virtualJoystick_view { get; private set; } = new();

        public async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await controller_inputAction_generic.Initialize_With_UniTask(_cancellationToken);

            input_model.Initialize();

            touch_input_model.Initialize();

            await virtualJoystick_view.Initialize_With_UniTask(_cancellationToken);
        }

        public void Begin()
        {
            controller_inputAction_generic.Begin();

            input_model.Begin();

            touch_input_model.Begin();
        }
    }
}