#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct UnitTest02StateMachineTopDown
    {
        public static StateMachineTopDown stateMachine { get; private set; }

        public static void CheckInitialize()
        {
            stateMachine = FactoryStateMachineTopDown.New(FactoryStateMachineTopDown.Type.player);

            stateMachine.Initialize();
        }

        public static void CheckVariable()
        {
            Assert.AreEqual(stateMachine.iStateIdle.name, nameof(StateMachineTopDown.Index.idle));
            Assert.AreEqual(stateMachine.iStateWalk.name, nameof(StateMachineTopDown.Index.walk));
        }
    }
}
#endif