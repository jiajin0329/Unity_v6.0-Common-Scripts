#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    public struct _03_Touch_Input_Model_UnitTest
    {
        public static Touch_Input_Model model { get; private set; }

        public static void Check_Initialize()
        {
            model = new();

            model.Initialize();
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(model.start_touch_vector2 == Vector2.zero);
            Assert.IsTrue(model.touch_vector2 == Vector2.zero);
            Assert.IsTrue(model.touch_range_radius_pixel == Touch_Input_Model.start_touch_range_radius_pixel);
        }
    }
}
#endif