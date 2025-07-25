#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _05_Input_Generic_Variable_Viewer_UnitTest
    {
        private static Input_Generic_Variable_Viewer _variable_viewer;

        public static async UniTask Check_Initialize()
        {
            _variable_viewer = new();
            _variable_viewer._model = _02_Input_Generic_Model_UnitTest.model;

            await Process.Check_Initialize_With_UniTask(_variable_viewer);
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(_variable_viewer.is_variable_text_notNull);
        }
    }
}
#endif