namespace Logy.Unity_Common_v01
{
    public interface IController_InputAction
    {
        public Input_Type input_type { get; }
        public enum Input_Type
        {
            Keyboard,
            Touchscreen
        }

        public void Remove_All_inputAction_Listener();
    }
}