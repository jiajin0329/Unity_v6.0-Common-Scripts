#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _03_Player_State_TopDown_UnitTest
    {
        private static State_TopDown _state;

        public static void Check_Initialize()
        {
            _state = new(nameof(State_TopDown), _02_StateMachine_TopDown_UnitTest.stateMachine);

            _state.Initialize();
        }

        public static void Check_Variable()
        {
            Assert.AreEqual(_state.name, nameof(State_TopDown));
        }
    }
}
#endif