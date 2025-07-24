using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public struct Convert
    {
        public static float Vector2_To_Distance(Vector2 _vector2)
        {
            return Mathf.Pow(_vector2.x * _vector2.x + _vector2.y * _vector2.y, 0.5f);
        }

        public static float Vector2_To_Radian(Vector2 _vector2)
        {
            return Mathf.Atan2(_vector2.x, _vector2.y);
        }
    }
}