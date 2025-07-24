#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _04_VirtualJoystick_View_UnitTest
    {
        private static VirtualJoystick_View _virtualJoystick_view;

        public static async UniTask Check_Initialize()
        {
            _virtualJoystick_view = new();
            
            await Process.Check_Initialize_With_UniTask(_virtualJoystick_view);
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(_virtualJoystick_view.is_root_ui_notNull);
        }
    }
}
#endif