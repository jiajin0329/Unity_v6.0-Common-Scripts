#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct UnitTest01GameData
    {
        private static GameData gameData;

        public static void CheckInitialize()
        {
            gameData = new();

            gameData = gameData.InitializeWithReturn();
        }

        public static void CheckVariable()
        {
            Assert.AreNotEqual(gameData, new GameData());
        }
    }
}
#endif