#if UNITY_EDITOR

using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public struct UnitTest02PlayerViewTopDown
    {
        private static PlayerViewTopDown _view;

        public static async UniTask CheckInitialize()
        {
            _view = new();

            CancellationTokenSource _cancellationTokenSource = new();
            await _view.InitializeWithUniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }
    }
}
#endif