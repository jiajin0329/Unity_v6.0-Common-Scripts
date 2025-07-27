#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _04_Variable_Viewer_UnitTest
    {
        private static Variable_Viewer _variable_viewer;

        public static async UniTask Check_Initialize()
        {
            _variable_viewer = new();

            CancellationTokenSource _cancellationTokenSource = new();
            await _variable_viewer.Initialize_With_UniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(_variable_viewer.is_variable_text_notNull);
        }
    }
}
#endif