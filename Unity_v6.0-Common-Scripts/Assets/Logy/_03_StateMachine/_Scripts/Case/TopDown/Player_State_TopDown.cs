namespace Logy.Unity_Common_v01
{
    public class Player_State_TopDown : State
    {
        private static float _input_distance;
        private static float _input_radian;
        private static bool is_move => _input_distance > 0.2f;

        public Player_State_TopDown(string _name) : base(_name) {}

        public override byte Get_Next_State_Index()
        {
            if (is_move)
            {
                if (Is.Right_Radian(_input_radian)) return StateMachine_Model_TopDown.Index.walk_right;
                else if (Is.Left_Radian(_input_radian)) return StateMachine_Model_TopDown.Index.walk_left;
                else if (Is.Up_Radian(_input_radian)) return StateMachine_Model_TopDown.Index.walk_up;
                else return StateMachine_Model_TopDown.Index.walk_down;
            }
            else
            {
                if (Is.Right_Radian(_input_radian)) return StateMachine_Model_TopDown.Index.idle_right;
                else if (Is.Left_Radian(_input_radian)) return StateMachine_Model_TopDown.Index.idle_left;
                else if (Is.Up_Radian(_input_radian)) return StateMachine_Model_TopDown.Index.idle_up;
                else return StateMachine_Model_TopDown.Index.idle_down;
            }
        }

        public static void Set_input_distance(float _input_distance)
        {
            Player_State_TopDown._input_distance = _input_distance;
        }
        
        public static void Set_input_radian(float _input_radian)
        {
            Player_State_TopDown._input_radian = _input_radian;
        }
    }
}