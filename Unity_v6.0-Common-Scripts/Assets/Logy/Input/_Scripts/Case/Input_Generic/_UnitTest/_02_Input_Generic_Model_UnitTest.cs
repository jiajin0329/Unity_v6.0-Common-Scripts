#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    public struct _02_Input_Generic_Model_UnitTest
    {
        public static Player_Input_Generic_Model model { get; private set; }

        public static async UniTask Check_Initialize()
        {
            model = new();

            CancellationTokenSource _cancellationTokenSource = new();
            await model.Initialize_With_UniTask(_cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();
        }

        public static void Remove_All_inputAction_Listener()
        {
            model.controller.Remove_All_inputAction_Listener();
        }
    }
}
#endif