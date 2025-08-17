using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class Player_Input_Generic_Model : IPlayer_Input_Generic_Model
    {
        [field: SerializeField]
        private Controller_InputAction_Generic _controller_inputAction_generic = new();
        public IController_InputAction controller => _controller_inputAction_generic;
        [field: SerializeField]
        private Input_Model _input_model = new();
        public IInput_Model input_model => _input_model;
        [field: SerializeField]
        private Touch_Input_Model _touch_input_model = new();
        public ITouch_Input_Model touch_input_model => _touch_input_model;

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            await _controller_inputAction_generic.Variable_Null_Handle(_cancellationToken);
        }

        public async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            _input_model.Initialize();

            _touch_input_model.Set_Reference(_input_model);
            _touch_input_model.Initialize();

            _controller_inputAction_generic.Set_Reference(_touch_input_model, _input_model);
            await _controller_inputAction_generic.Initialize_With_UniTask(_cancellationToken);
        }
    }
}