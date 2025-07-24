#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    public struct _02_Input_Generic_Model_UnitTest
    {
        public static Input_Generic_Model model { get; private set; }

        public static async UniTask Check_Initialize()
        {
            model = new();

            await Process.Check_Initialize_With_UniTask(model);
        }

        public static void Check_Begin()
        {
            Process.Check_Begin(model);
        }

        public static void Remove_All_inputAction_Listener()
        {
            model.controller_inputAction_generic.Remove_All_inputAction_Listener();
        }
    }
}
#endif