#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _04_Variable_Viewer_UnitTest
    {
        private static Variable_Viewer _variable_viewer;

        public static async UniTask Check_Initialize()
        {
            _variable_viewer = new(nameof(Variable_Viewer));

            await Process.Check_Initialize_With_UniTask(_variable_viewer);
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(_variable_viewer.is_variable_text_notNull);
        }
    }
}
#endif