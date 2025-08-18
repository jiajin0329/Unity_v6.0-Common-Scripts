#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct UnitTest02State
    {
        private static StateTest state;
        private class StateTest : State
        {
            public StateTest(string _name) : base(_name) {}

            public override byte GetNextStateIndex() { return 0; }
        }

        public static void CheckInitialize()
        {
            state = new(nameof(StateTest));

            state.Initialize();
        }
        
        public static void CheckVariable()
        {
            Assert.AreEqual(state.name, nameof(StateTest));
        }
    }
}
#endif