#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _01_Player_View_TopDown_UnitTest
    {
        public static Player_View_TopDown view { get; private set; }

        public static async UniTask Check_Initialize()
        {
            Build_Object();

            await Process.Check_Initialize_With_UniTask(view);
        }

        private static void Build_Object()
        {
            view = new();

            Player_View_TopDown.Data _data = new()
            {
                input_model = _02_Input_Model_UnitTest.model,
                stateMachine_model = _02_StateMachine_Model_TopDown_UnitTest.model,
            };

            view.Set_Reference(_data);
        }

        public static void Check_Variable()
        {
            Assert.AreEqual(view.is_prefab_is_notNull, true);
            Assert.AreEqual(view.is_animator_is_notNull, true);
        }
    }
}
#endif