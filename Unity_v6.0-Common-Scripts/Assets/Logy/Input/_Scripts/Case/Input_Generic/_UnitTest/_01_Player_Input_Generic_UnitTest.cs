#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _01_Player_Input_Generic_UnitTest
    {
        private static Player_Input_Generic _input;

        public static async UniTask Check_Initialize()
        {
            _input = new();

            await Process.Check_Initialize_With_UniTask(_input);
        }

        public static void Check_Begin()
        {
            Process.Check_Begin(_input);
        }

        public static void Check_Get_Variable_Listener()
        {
            Assert.IsTrue(_input._model.virtualJoystick_view.touch_range_radius_pixel != 0f);
        }

        public static void Remove_All_inputAction_Listener()
        {
            _input._model.controller_inputAction_generic.Remove_All_inputAction_Listener();
        }
    }
}
#endif