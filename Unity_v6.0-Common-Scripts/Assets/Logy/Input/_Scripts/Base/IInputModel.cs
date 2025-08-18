using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IInputModel
    {
        public bool inputDown { get; }
        public bool input { get; }
        public bool inputUp { get; }
        public bool isInput => inputDown || input;
        public Vector2 inputVector2 { get; }
        public float inputRadian { get; }
        
        public event UnityAction InputDownAction;
        public event UnityAction InputAction;
        public event UnityAction InputUpAction;
    }
}