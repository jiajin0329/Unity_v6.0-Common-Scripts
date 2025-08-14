namespace Logy.Unity_Common_v01
{
    public interface IPlayer_Input_Generic_Model
    {
        public IController_InputAction controller { get; }
        public IInput_Model input_model { get; }
        public ITouch_Input_Model touch_input_model { get; }

    }
}