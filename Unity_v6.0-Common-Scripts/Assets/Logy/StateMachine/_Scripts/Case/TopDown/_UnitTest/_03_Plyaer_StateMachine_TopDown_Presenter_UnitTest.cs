#if UNITY_EDITOR

namespace Logy.Unity_Common_v01
{
    public struct _03_Plyaer_StateMachine_TopDown_Presenter_UnitTest
    {
        private static Plyaer_StateMachine_TopDown_Presenter _presenter;

        public static void Check_Initialize()
        {
            Build_Data();
            
            Process.Check_Initialize(_presenter);
        }

        private static void Build_Data()
        {
            _presenter = new();
            Plyaer_StateMachine_TopDown_Presenter.Data _data = new()
            {
                stateMachine_model = _02_StateMachine_Model_TopDown_UnitTest.model,
                input_model = _02_Input_Model_UnitTest.model,
            };

            _presenter.Set_Reference(_data);
        }
    }
}
#endif