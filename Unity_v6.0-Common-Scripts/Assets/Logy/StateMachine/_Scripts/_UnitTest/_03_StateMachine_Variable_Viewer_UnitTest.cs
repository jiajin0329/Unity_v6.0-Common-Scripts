#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _03_StateMachine_Variable_Viewer_UnitTest
    {
        private static StateMachine_Variable_Viewer _variable_viewer;

        public static async UniTask Check_Initialize()
        {
            _variable_viewer = new();
            _variable_viewer.Set_Reference(_01_StateMachine_UnitTest.stateMachine);

            await Process.Check_Initialize_With_UniTask(_variable_viewer);
        }
        
        public static void Check_Variable()
        {
            Assert.IsTrue(_variable_viewer.is_variable_text_notNull);
        }
    }
}
#endif