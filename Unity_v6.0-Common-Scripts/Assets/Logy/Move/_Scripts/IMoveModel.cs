using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IMoveModel
    {
        public Vector2 velocity { get; }
        public float speedRatio { get; }
        public float moveRadian { get; }

        public event UnityAction TickAction;

        public void Tick();
    }
}