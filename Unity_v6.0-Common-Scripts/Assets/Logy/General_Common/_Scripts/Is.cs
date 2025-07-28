using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface Is
    {
        public static bool Variable_Null(object _target, string _name)
        {
            if (_target == null)
            {
                Debug.LogWarning($"{_name} is null");
                return true;
            }

            // For UnityEngine.Object, null check is special due to Unity's custom == operator
            if (_target is UnityEngine.Object unityObj && unityObj == null)
            {
                Debug.LogWarning($"{_name} is null (Unity override)");
                return true;
            }

            return false;
        }

        public static bool UnityAction_Null(UnityAction _unityAction)
        {
            return _unityAction != null;
        }

        public interface Radian
        {
            private const float _upper_left_radian = -0.7853982f;
            private const float _upper_right_radian = 0.7853982f;
            private const float _lower_left_radian = -2.356194f;
            private const float _lower_right_radian = 2.356194f;

            public static bool Down(float _radian) { return _radian <= _lower_left_radian && _radian >= _lower_right_radian; }

            public static bool Left(float _radian) { return _radian < _upper_left_radian && _radian > _lower_left_radian; }

            public static bool Right (float _radian) { return _radian > _upper_right_radian && _radian < _lower_right_radian ; }
            
            public static bool Up(float _radian) { return _radian >= _upper_left_radian && _radian <= _upper_right_radian; }
        }
    }
}