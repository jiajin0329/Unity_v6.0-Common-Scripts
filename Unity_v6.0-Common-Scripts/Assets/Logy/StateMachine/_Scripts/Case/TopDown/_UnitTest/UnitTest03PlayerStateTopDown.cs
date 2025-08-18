#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct UnitTest03PlayerStateTopDown
    {
        private static StateTopDown _state;

        public static void CheckInitialize()
        {
            _state = new(nameof(StateTopDown), UnitTest02StateMachineTopDown.stateMachine);
            _state.Initialize();
        }

        public static void CheckVariable()
        {
            Assert.AreEqual(_state.name, nameof(StateTopDown));
        }
    }
}
#endif