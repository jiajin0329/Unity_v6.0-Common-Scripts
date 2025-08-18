#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public struct UnitTest02InputGenericModel
    {
        public static PlayerInputGenericModel model { get; private set; }

        public static async UniTask CheckInitialize()
        {
            model = new();

            CancellationTokenSource _cancellationTokenSource = new();
            await model.InitializeWithUniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }

        public static void RemoveAllInputActionListener()
        {
            model.controller.RemoveAllInputActionListener();
        }
    }
}
#endif