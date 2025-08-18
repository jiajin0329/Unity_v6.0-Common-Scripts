#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    public struct UnitTest03TouchInputModel
    {
        public static TouchInputModel model { get; private set; }

        public static void CheckInitialize()
        {
            model = new();

            model.Initialize();
        }

        public static void CheckVariable()
        {
            Assert.IsTrue(model.startTouchVector2 == Vector2.zero);
            Assert.IsTrue(model.touchVector2 == Vector2.zero);
            Assert.IsTrue(model.touchRangeRadiusPixel == TouchInputModel.startTouchRangeRadiusPixel);
        }
    }
}
#endif