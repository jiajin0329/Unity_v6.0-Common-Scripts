using System;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Input_Generic_Presenter
    {
        private Input_Generic_Model _model;

        public void Set_Reference(Input_Generic_Model _model) { this._model = _model; }

        public void Initialize()
        {
            Add_Touch_Controller_Listener();
            Add_Controller_Listener();
        }

        private void Add_Touch_Controller_Listener()
        {
            Add_Get_touch_range_radius_pixel_Listener();

            Add_TouchDown_Listener();

            Add_Get_touch_input_vector2_Listener();

            Add_Get_Touch_Listener();

            Add_Get_TouchUp_Listener();
        }

        private void Add_Get_touch_range_radius_pixel_Listener()
        {
            _model.touch_input_model.Get_touch_range_radius_pixel_Action += _model.virtualJoystick_view.Set_touch_range_radius_pixel;
        }

        private void Add_TouchDown_Listener()
        {
            _model.controller_inputAction_generic.TouchDown_Action += _model.touch_input_model.OnTouchDown;
            _model.touch_input_model.TouchDown_Action += _model.input_model.OnInputDown;
            _model.touch_input_model.TouchDown_Action += _model.virtualJoystick_view.Show_UI;
        }

        private void Add_Get_touch_input_vector2_Listener()
        {
            _model.controller_inputAction_generic.Get_start_touch_vector2_Action += _model.touch_input_model.Set_touch_start_vector2;
            _model.controller_inputAction_generic.Get_start_touch_vector2_Action += _model.virtualJoystick_view.Set_UI_Position;

            _model.controller_inputAction_generic.Get_touch_vector2_Action += _model.touch_input_model.Set_touch_vector2;
            _model.touch_input_model.Get_input_vector2_Action += _model.input_model.Set_input_vector2;
            _model.touch_input_model.Get_input_vector2_Action += _model.virtualJoystick_view.Set_Stick_Position;
        }

        private void Add_Get_Touch_Listener()
        {
            _model.controller_inputAction_generic.Touch_Action += _model.touch_input_model.OnTouch;
            _model.touch_input_model.Touch_Action += _model.input_model.OnInput;
        }

        private void Add_Get_TouchUp_Listener()
        {
            _model.controller_inputAction_generic.TouchUp_Action += _model.touch_input_model.OnTouchUp;
            _model.touch_input_model.TouchUp_Action += _model.input_model.OnInputUp;
            _model.touch_input_model.TouchUp_Action += _model.virtualJoystick_view.Hide_UI;
        }

        private void Add_Controller_Listener()
        {
            Add_input_vector2_Listener();

            Add_InputDown_Listener();

            Add_Input_Listener();

            Add_InputUp_Listener();
        }

        private void Add_input_vector2_Listener()
        {
            _model.controller_inputAction_generic.Get_input_vector2_Action += _model.input_model.Set_input_vector2;
        }

        private void Add_InputDown_Listener()
        {
            _model.controller_inputAction_generic.InputDown_Action += _model.input_model.OnInputDown;
            _model.controller_inputAction_generic.InputDown_Action += _model.virtualJoystick_view.Hide_UI;
        }

        private void Add_Input_Listener()
        {
            _model.controller_inputAction_generic.Input_Action += _model.input_model.OnInput;
        }

        private void Add_InputUp_Listener()
        {
            _model.controller_inputAction_generic.InputUp_Action += _model.input_model.OnInputUp;
        }
    }
}