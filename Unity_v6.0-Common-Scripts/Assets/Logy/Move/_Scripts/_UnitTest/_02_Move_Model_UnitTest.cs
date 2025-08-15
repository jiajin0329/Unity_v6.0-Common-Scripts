#if UNITY_EDITOR

namespace Logy.Unity_Common_v01
{
    public struct _02_Move_Model_UnitTest
    {
        public static Move_Model model { get; private set; }

        public static void Check_Initialize()
        {
            Build_Object();

            model.Initialize();
        }

        private static void Build_Object()
        {
            model = new();
            model.Set_Reference(_02_Input_Model_UnitTest.model);
        }
    }
}
#endif