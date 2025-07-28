#if UNITY_EDITOR

namespace Logy.Unity_Common_v01
{
    public struct _03_Player_StateMachine_TopDown_Presenter_UnitTest
    {
        private static Player_StateMachine_TopDown_Presenter _presenter;

        public static void Check_Initialize()
        {
            Build_Data();

            _presenter.Initialize();
        }

        private static void Build_Data()
        {
            _presenter = new();
            Player_StateMachine_TopDown_Presenter.Data _data = new()
            {
                stateMachine = _02_StateMachine_TopDown_UnitTest.stateMachine,
                input_model = _02_Input_Model_UnitTest.model,
            };

            _presenter.Set_Reference(_data);
        }
    }
}
#endif