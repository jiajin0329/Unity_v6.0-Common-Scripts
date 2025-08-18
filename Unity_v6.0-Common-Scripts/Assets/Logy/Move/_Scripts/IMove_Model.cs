using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IMove_Model
    {
        public Vector2 velocity { get; }
        public float speed_ratio { get; }
        public float move_radian { get; }
        public IInputModel inputModel { get; }

        public event UnityAction Tick_Action;
    }
}