#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct UnitTest04VirtualJoystickView
    {
        private static VirtualJoystickView _view;

        public static async UniTask CheckInitialize()
        {
            _view = new();
            _view.SetReference(UnitTest03TouchInputModel.model, UnitTest02InputModel.model);
            
            CancellationTokenSource _cancellationTokenSource = new();
            await _view.InitializeWithUniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }

        public static void CheckVariable()
        {
            Assert.IsTrue(_view.isRootUiNotNull);
        }
    }
}
#endif