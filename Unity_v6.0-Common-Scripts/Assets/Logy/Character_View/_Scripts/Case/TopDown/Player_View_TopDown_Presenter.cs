using System;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_View_TopDown_Presenter
    {
        private Data _data;
        public struct Data
        {
            public Player_View_TopDown player_view_topDown;
            public Input_Model input_model;
            public IStateMachine_Model_TopDown stateMachine_model;
        }

        public void Set_Reference(Data _data) { this._data = _data; }

        public void Initialize()
        {
            Add_Character_View_Action(_data.player_view_topDown);

            _data.input_model.Get_input_distance_Action += _data.player_view_topDown.Update_Animator_Speed;
        }

        private void Add_Character_View_Action(Player_View_TopDown _character_view_topDown)
        {
            _data.stateMachine_model.state_idle_down.Start_Action += _character_view_topDown.Idle_Down_View;
            _data.stateMachine_model.state_idle_left.Start_Action += _character_view_topDown.Idle_Left_View;
            _data.stateMachine_model.state_idle_right.Start_Action += _character_view_topDown.Idle_Right_View;
            _data.stateMachine_model.state_idle_up.Start_Action += _character_view_topDown.Idle_Up_View;
            _data.stateMachine_model.state_walk_down.Start_Action += _character_view_topDown.Walk_Down_View;
            _data.stateMachine_model.state_walk_left.Start_Action += _character_view_topDown.Walk_Left_View;
            _data.stateMachine_model.state_walk_right.Start_Action += _character_view_topDown.Walk_Right_View;
            _data.stateMachine_model.state_walk_up.Start_Action += _character_view_topDown.Walk_Up_View;
        }
    }
}