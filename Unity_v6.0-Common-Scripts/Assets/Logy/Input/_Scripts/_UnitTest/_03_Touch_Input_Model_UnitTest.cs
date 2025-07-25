#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public struct _03_Touch_Input_Model_UnitTest
    {
        private static Touch_Input_Model _model;

        public static void Check_Initialize()
        {
            _model = new();
            
            Process.Check_Initialize(_model);
        }

        public static void Check_Begin()
        {
            Process.Check_Begin(_model);
        }

        public static void Check_Variable()
        {
            Assert.IsTrue(_model.start_touch_vector2 == Vector2.zero);
            Assert.IsTrue(_model.touch_vector2 == Vector2.zero);
            Assert.IsTrue(_model.touch_range_radius_pixel == Touch_Input_Model.start_touch_range_radius_pixel);
        }
    }
}
#endif