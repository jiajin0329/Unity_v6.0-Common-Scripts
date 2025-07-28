#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _02_StateMachine_TopDown_UnitTest
    {
        public static StateMachine_TopDown stateMachine { get; private set; }

        public static void Check_Initialize()
        {
            stateMachine = Factory_StateMachine_TopDown.New(Factory_StateMachine_TopDown.Type.player);

            stateMachine.Initialize();
        }

        public static void Check_Variable()
        {
            Assert.AreEqual(stateMachine.iState_idle.name, nameof(StateMachine_TopDown.Index.idle));
            Assert.AreEqual(stateMachine.iState_walk.name, nameof(StateMachine_TopDown.Index.walk));
        }
    }
}
#endif