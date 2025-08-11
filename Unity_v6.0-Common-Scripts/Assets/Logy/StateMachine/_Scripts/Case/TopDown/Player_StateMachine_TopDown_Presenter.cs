using System;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_StateMachine_TopDown_Presenter
    {
        private Data _data;
        public struct Data
        {
            public StateMachine_TopDown stateMachine;
            public IMove_Model move_model;
        }

        public void Set_Reference(Data _data) { this._data = _data; }

        public void Initialize()
        {
            _data.move_model.Tick_Action += _data.stateMachine.Tick;
            _data.move_model.Tick_Action += _data.stateMachine.Switch_Direction;
        }
    }
}