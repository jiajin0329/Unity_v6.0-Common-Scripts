#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct _04_Input_Generic_Variable_Viewer_UnitTest
    {
        private static Input_Generic_Variable_Viewer _variable_viewer;

        public static async UniTask Check_Initialize()
        {
            _variable_viewer = new();
            _variable_viewer._model = _02_Input_Generic_Model_UnitTest.model;

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