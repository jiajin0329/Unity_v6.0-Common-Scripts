using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface Is
    {
        public static bool VariableNull(object _target, string _name)
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

        public static bool UnityActionNull(UnityAction _unityAction)
        {
            return _unityAction != null;
        }

        public interface Radian
        {
            private const float _upperLeftRadian = -0.7853982f;
            private const float _upperRightRadian = 0.7853982f;
            private const float _lowerLeftRadian = -2.356194f;
            private const float _lowerRightRadian = 2.356194f;

            public static bool Down(float _radian) { return _radian <= _lowerLeftRadian && _radian >= _lowerRightRadian; }

            public static bool Left(float _radian) { return _radian < _upperLeftRadian && _radian > _lowerLeftRadian; }

            public static bool Right (float _radian) { return _radian > _upperRightRadian && _radian < _lowerRightRadian; }
            
            public static bool Up(float _radian) { return _radian >= _upperLeftRadian && _radian <= _upperRightRadian; }
        }
    }
}