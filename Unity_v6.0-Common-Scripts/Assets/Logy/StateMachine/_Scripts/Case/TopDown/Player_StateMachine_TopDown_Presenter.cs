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
            public Input_Model input_model;
        }

        public void Set_Reference(Data _data) { this._data = _data; }
        
        public void Initialize()
        {
            _data.input_model.Get_input_distance_Action += _data.stateMachine.Set_input_distance;
            _data.input_model.Get_input_radian_Action += _data.stateMachine.Switch_Direction;

            _data.input_model.InputDown_Action += _data.stateMachine.Update;
            _data.input_model.Input_Action += _data.stateMachine.Update;
            _data.input_model.InputUp_Action += _data.stateMachine.Update;
        }
    }
}