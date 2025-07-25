using System;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public struct Factory_StateMachine_Model_TopDown
    {
        public enum Type : byte
        {
            player,
        }

        public static StateMachine_Model_TopDown New(Type _type)
        {
            if (_type is Type.player)
            {
                StateMachine_Model_TopDown.State_Data _all_next_state_handler_data = new()
                {
                    idle_down = new Player_State_TopDown(nameof(StateMachine_Model_TopDown.Index.idle_down)),
                    idle_left = new Player_State_TopDown(nameof(StateMachine_Model_TopDown.Index.idle_left)),
                    idle_right = new Player_State_TopDown(nameof(StateMachine_Model_TopDown.Index.idle_right)),
                    idle_up = new Player_State_TopDown(nameof(StateMachine_Model_TopDown.Index.idle_up)),
                    walk_down = new Player_State_TopDown(nameof(StateMachine_Model_TopDown.Index.walk_down)),
                    walk_left = new Player_State_TopDown(nameof(StateMachine_Model_TopDown.Index.walk_left)),
                    walk_right = new Player_State_TopDown(nameof(StateMachine_Model_TopDown.Index.walk_right)),
                    walk_up = new Player_State_TopDown(nameof(StateMachine_Model_TopDown.Index.walk_up)),
                };

                return new(_all_next_state_handler_data);
            }

            return null;
        }
    }
}