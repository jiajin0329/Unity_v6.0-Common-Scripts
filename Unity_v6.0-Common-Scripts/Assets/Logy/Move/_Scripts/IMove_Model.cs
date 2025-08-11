using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface IMove_Model
    {
        public Vector2 velocity { get; }
        public float speed_ratio { get; }
        public float move_radian { get; }

        public event UnityAction Tick_Action;
    }
}