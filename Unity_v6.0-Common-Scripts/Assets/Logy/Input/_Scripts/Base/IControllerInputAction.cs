namespace Logy.UnityCommonV01
{
    public interface IControllerInputAction
    {
        public InputType inputType { get; }
        public enum InputType
        {
            keyboard,
            touchScreen
        }

        public void RemoveAllInputActionListener();
    }
}