#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _01_Game_Data_UnitTest
    {
        private static Game_Data game_data;

        public static void Check_Initialize()
        {
            game_data = new();

            game_data = game_data.Initialize_With_Return();
        }

        public static void Check_Variable()
        {
            Assert.AreNotEqual(game_data, new Game_Data());
        }
    }
}
#endif