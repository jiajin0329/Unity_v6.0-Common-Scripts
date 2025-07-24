#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _04_Player_State_TopDown_UnitTest
    {
        private static Player_State_TopDown _state;

        public static void Check_Initialize()
        {
            _state = new(nameof(Player_State_TopDown));
            
            Process.Check_Initialize(_state);
        }

        public static void Check_Variable()
        {
            Assert.AreEqual(_state.name, nameof(Player_State_TopDown));
        }
    }
}
#endif