#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _04_Controller_InputAction_Generic_UnitTest
    {
        private static Controller_InputAction_Generic _controller_inputAction;

        public static async UniTask Check_Initialize()
        {
            _controller_inputAction = new();

            await Process.Check_Initialize_With_UniTask(_controller_inputAction);
        }

        public static void Check_Begin()
        {
            Process.Check_Begin(_controller_inputAction);
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(_controller_inputAction.is_inputActionAsset_notNull);
            Assert.IsTrue(_controller_inputAction.is_move_inputAction_notNull);
            Assert.IsTrue(_controller_inputAction.is_touchPress_inputAction_notNull);
        }

        public static void Remove_All_inputAction_Listener()
        {
            _controller_inputAction.Remove_All_inputAction_Listener();
        }
    }
}
#endif