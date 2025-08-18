#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTest01ControllerInputAction
    {
        private static ControllerInputAction _controllerInputAction;

        public static async UniTask CheckInitialize()
        {
            _controllerInputAction = new();

            CancellationTokenSource _cancellationTokenSource = new();
            await _controllerInputAction.InitializeWithUniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }

        public static void CheckVariable()
        {
            Assert.IsTrue(_controllerInputAction.isInputActionAssetNotNull);
            Assert.IsTrue(_controllerInputAction.isMoveInputActionNotNull);
        }

        public static void RemoveAllInputActionListener()
        {
            _controllerInputAction.RemoveAllInputActionListener();
        }
    }
}
#endif