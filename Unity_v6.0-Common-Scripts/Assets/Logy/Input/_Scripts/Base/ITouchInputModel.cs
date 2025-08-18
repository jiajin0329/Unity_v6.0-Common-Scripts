using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface ITouchInputModel
    {
        public Vector2 startTouchVector2 { get; }
        public Vector2 touchVector2 { get; }
        public float touchRangeRadiusPixel { get; }

        public event UnityAction TouchDownAction;
        public event UnityAction TouchAction;
        public event UnityAction TouchUpAction;
    }
}