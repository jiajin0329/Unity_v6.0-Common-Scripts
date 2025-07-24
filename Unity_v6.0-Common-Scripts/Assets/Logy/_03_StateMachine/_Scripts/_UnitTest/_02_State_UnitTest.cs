#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _02_State_UnitTest
    {
        private static State_Test state;
        private class State_Test : State
        {
            public State_Test(string _name) : base(_name) {}

            public override byte Get_Next_State_Index() { return 0; }
        }

        public static void Check_Initialize()
        {
            state = new(nameof(State_Test));
            
            Process.Check_Initialize(state);
        }
        
        public static void Check_Variable()
        {
            Assert.AreEqual(state.name, nameof(State_Test));
        }
    }
}
#endif