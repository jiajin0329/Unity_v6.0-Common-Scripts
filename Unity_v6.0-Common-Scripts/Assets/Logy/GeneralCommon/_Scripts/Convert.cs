using UnityEngine;

namespace Logy.UnityCommonV01
{
    public struct Convert
    {
        public static float Vector2ToRadian(Vector2 _vector2)
        {
            return Mathf.Atan2(_vector2.x, _vector2.y);
        }
    }
}