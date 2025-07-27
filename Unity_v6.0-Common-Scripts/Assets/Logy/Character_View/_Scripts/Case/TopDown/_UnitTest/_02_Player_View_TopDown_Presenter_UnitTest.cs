#if UNITY_EDITOR

namespace Logy.Unity_Common_v01
{
    public struct _02_Player_View_TopDown_Presenter_UnitTest
    {
        private static Player_View_TopDown_Presenter _presenter;

        public static void Check_Initialize()
        {
            Build_Object();

            _presenter.Initialize();
        }

        private static void Build_Object()
        {
            _presenter = new();

            Player_View_TopDown_Presenter.Data _data = new()
            {
                player_view_topDown = _01_Player_View_TopDown_UnitTest.view,
                input_model = _02_Input_Model_UnitTest.model,
                stateMachine_model = _02_StateMachine_Model_TopDown_UnitTest.model,
            };

            _presenter.Set_Reference(_data);
        }
    }
}
#endif