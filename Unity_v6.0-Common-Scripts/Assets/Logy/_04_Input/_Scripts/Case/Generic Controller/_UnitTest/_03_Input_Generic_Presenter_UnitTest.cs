#if UNITY_EDITOR
namespace Logy.Unity_Common_v01
{
    public struct _03_Input_Generic_Presenter_UnitTest
    {
        private static Input_Generic_Presenter _presenter;

        public static void Check_Initialize()
        {
            _presenter = new();
            _presenter.Set_Reference(_02_Input_Generic_Model_UnitTest.model);

            Process.Check_Initialize(_presenter);
        }
    }
}
#endif