using System;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Plyaer_StateMachine_TopDown_Presenter : Process
    {
        private Data _data;
        public struct Data
        {
            public IStateMachine_Model stateMachine_model;
            public Input_Model input_model;
        }

        public Plyaer_StateMachine_TopDown_Presenter() : base(nameof(Plyaer_StateMachine_TopDown_Presenter)) {}

        public void Set_Reference(Data _data) { this._data = _data; }
        
        protected override void Initialize_Detail()
        {
            _data.input_model.Get_input_distance_Action += Player_State_TopDown.Set_input_distance;
            _data.input_model.Get_input_radian_Action += Player_State_TopDown.Set_input_radian;

            _data.input_model.InputDown_Action += _data.stateMachine_model.Update;
            _data.input_model.Input_Action += _data.stateMachine_model.Update;
            _data.input_model.InputUp_Action += _data.stateMachine_model.Update;
        }
    }
}