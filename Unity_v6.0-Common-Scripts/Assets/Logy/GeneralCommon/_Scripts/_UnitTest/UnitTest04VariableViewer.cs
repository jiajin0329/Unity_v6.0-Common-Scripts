#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct UnitTest04VariableViewer
    {
        private static VariableViewer _variableViewer;

        public static async UniTask CheckInitialize()
        {
            _variableViewer = new();

            CancellationTokenSource _cancellationTokenSource = new();
            await _variableViewer.InitializeWithUniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }

        public static void CheckVariable()
        {
            Assert.IsTrue(_variableViewer.isVariableTextNotNull);
        }
    }
}
#endif