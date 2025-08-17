#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct _04_VirtualJoystick_View_UnitTest
    {
        private static VirtualJoystick_View _view;

        public static async UniTask Check_Initialize()
        {
            _view = new();
            _view.Set_Reference(_03_Touch_Input_Model_UnitTest.model, _02_Input_Model_UnitTest.model);
            
            CancellationTokenSource _cancellationTokenSource = new();
            await _view.Initialize_With_UniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(_view.is_root_ui_notNull);
        }
    }
}
#endif