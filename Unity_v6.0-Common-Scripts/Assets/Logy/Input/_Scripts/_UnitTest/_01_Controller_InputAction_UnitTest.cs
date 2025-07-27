#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _01_Controller_InputAction_UnitTest
    {
        private static Controller_InputAction _controller_inputAction;

        public static async UniTask Check_Initialize()
        {
            _controller_inputAction = new();

            CancellationTokenSource _cancellationTokenSource = new();
            await _controller_inputAction.Initialize_With_UniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }

        public static void Check_Begin()
        {
            _controller_inputAction.Begin();
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(_controller_inputAction.is_inputActionAsset_notNull);
            Assert.IsTrue(_controller_inputAction.is_move_inputAction_notNull);
        }

        public static void Remove_All_inputAction_Listener()
        {
            _controller_inputAction.Remove_All_inputAction_Listener();
        }
    }
}
#endif