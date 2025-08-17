#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct _03_StateMachine_Variable_Viewer_UnitTest
    {
        private static StateMachine_Variable_Viewer _variable_viewer;

        public static async UniTask Check_Initialize()
        {
            _variable_viewer = new();
            _variable_viewer.Set_Reference(_01_StateMachine_UnitTest.stateMachine);

            CancellationTokenSource _cancellationTokenSource = new();
            await _variable_viewer.InitializeWithUniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }
        
        public static void Check_Variable()
        {
            Assert.IsTrue(_variable_viewer.isVariableTextNotNull);
        }
    }
}
#endif