using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class Player_Input_Generic_Presenter : Process, IHasInitializeWithUniTask, IHasTick
    {
        [SerializeField]
        private Player_Input_Generic_Model _model = new();
        public IPlayer_Input_Generic_Model model => _model;
        [field: SerializeField]
        public VirtualJoystick_View virtualJoystick_view { get; private set; } = new();
#if DEBUG
        [field: SerializeField]
        public Input_Generic_Variable_Viewer variable_viewer { get; private set; } = new();
#endif

        public Player_Input_Generic_Presenter() : base(nameof(Player_Input_Generic_Presenter)) {}

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            await _model.Variable_Null_Handle(_cancellationToken);

            await virtualJoystick_view.Variable_Null_Handle(_cancellationToken);

#if DEBUG
            await variable_viewer.VariableNullHandle(_cancellationToken);
#endif
        }

        protected override async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            await _model.Initialize_With_UniTask(_cancellationToken);

            virtualJoystick_view.Set_Reference(_model.touch_input_model, _model.input_model);
            await virtualJoystick_view.Initialize_With_UniTask(_cancellationToken);

            Add_Touch_Listener();

#if DEBUG
            variable_viewer.Set_Reference(_model);
            await variable_viewer.InitializeWithUniTask(_cancellationToken);
#endif
        }

        private void Add_Touch_Listener()
        {
            Add_OnTouchDown_Listener();
            Add_OnTouch_Listener();
            Add_OnTouchUp_Listener();
        }

        private void Add_OnTouchDown_Listener()
        {
            _model.touch_input_model.TouchDown_Action += virtualJoystick_view.Show_UI;
            _model.touch_input_model.TouchDown_Action += virtualJoystick_view.Tick;
        }

        private void Add_OnTouch_Listener()
        {
            _model.touch_input_model.Touch_Action += virtualJoystick_view.Tick;
        }

        private void Add_OnTouchUp_Listener()
        {
            _model.touch_input_model.TouchUp_Action += virtualJoystick_view.Hide_UI;
            _model.touch_input_model.TouchUp_Action += virtualJoystick_view.Tick;
        }
    }
}