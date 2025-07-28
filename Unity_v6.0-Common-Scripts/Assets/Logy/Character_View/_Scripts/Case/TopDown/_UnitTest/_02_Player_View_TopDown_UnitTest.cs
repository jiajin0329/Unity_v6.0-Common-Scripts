#if UNITY_EDITOR

using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    public struct _02_Player_View_TopDown_UnitTest
    {
        private static Player_View_TopDown _view;

        public static async UniTask Check_Initialize()
        {
            _view = new();

            CancellationTokenSource _cancellationTokenSource = new();
            await _view.Initialize_With_UniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }
    }
}
#endif