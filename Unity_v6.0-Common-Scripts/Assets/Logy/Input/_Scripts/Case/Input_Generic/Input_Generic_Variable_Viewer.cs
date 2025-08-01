#if UNITY_WEBGL && DEBUG
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Input_Generic_Variable_Viewer : Variable_Viewer
    {
        private Variable_UI _input_type_variable_ui;
        private Variable_UI _inputDonw_variable_ui;
        private Variable_UI _input_variable_ui;
        private Variable_UI _inputUp_variable_ui;
        private Variable_UI _input_vector2_variable_ui;
        private Variable_UI _input_distance_variable_ui;
        private Variable_UI _input_radian_variable_ui;
        private Variable_UI _start_touch_vector2_variable_ui;
        private Variable_UI _touch_vector2_variable_ui;

        [NonSerialized] public Input_Generic_Model _model;

        public void Set_Reference(Input_Generic_Model _model) { this._model = _model; }

        public override async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await base.Initialize_With_UniTask(_cancellationToken);

            Initialize_Variable_Text();

            Add_Action_Listeners();
        }

        private void Initialize_Variable_Text()
        {
            // initialize the variable text
            _input_type_variable_ui.Initialize($"{nameof(Controller_InputAction.input_type)} : ", _variable_text, false);
            _inputDonw_variable_ui.Initialize($"{nameof(Input_Model.inputDown)} : ", _variable_text);
            _input_variable_ui.Initialize($"{nameof(Input_Model.input)} : ", _variable_text);
            _inputUp_variable_ui.Initialize($"{nameof(Input_Model.inputUp)} : ", _variable_text);
            _input_vector2_variable_ui.Initialize($"{nameof(Input_Model.input_vector2)} : ", _variable_text);
            _input_distance_variable_ui.Initialize($"{nameof(Input_Model.input_distance)} : ", _variable_text);
            _input_radian_variable_ui.Initialize($"{nameof(Input_Model.input_radian)} : ", _variable_text);

            _start_touch_vector2_variable_ui.Initialize($"{nameof(Touch_Input_Model.start_touch_vector2)} : ", _variable_text);
            _touch_vector2_variable_ui.Initialize($"{nameof(Touch_Input_Model.touch_vector2)} : ", _variable_text);
        }

        private void Add_Action_Listeners()
        {
            _model.controller_inputAction_generic.Get_input_type_Action += Update_input_type_variable_ui;

            _model.input_model.Get_inputDown_Action += Update_inputDonw_variable_ui;
            _model.input_model.Get_input_Action += Update_input_variable_ui;
            _model.input_model.Get_inputUp_Action += Update_inputUp_variable_ui;
            _model.input_model.Get_input_vector2_Action += Update_input_vector2_variable_ui;
            _model.input_model.Get_input_distance_Action += Update_input_distance_variable_ui;
            _model.input_model.Get_input_radian_Action += Update_input_radian_variable_ui;

            _model.touch_input_model.Get_start_touch_vector2_Action += Update_start_touch_vector2_variable_ui;
            _model.touch_input_model.Get_touch_vector2_Action += Update_touch_vector2_variable_ui;
        }

        private void Update_input_type_variable_ui(Controller_InputAction.Input_Type _input_Type)
        {
            _input_type_variable_ui.Update_Text(_input_Type.ToString());
        }

        private void Update_inputDonw_variable_ui(bool _inputDonw)
        {
            _inputDonw_variable_ui.Update_Text(_inputDonw.ToString());
        }

        private void Update_input_variable_ui(bool _input)
        {
            _input_variable_ui.Update_Text(_input.ToString());
        }

        private void Update_inputUp_variable_ui(bool _inputUp)
        {
            _inputUp_variable_ui.Update_Text(_inputUp.ToString());
        }

        private void Update_input_vector2_variable_ui(Vector2 _input_vector2)
        {
            _input_vector2_variable_ui.Update_Text(_input_vector2.ToString());
        }

        private void Update_input_distance_variable_ui(float _input_distance)
        {
            _input_distance_variable_ui.Update_Text(_input_distance.ToString());
        }

        private void Update_input_radian_variable_ui(float _input_radian)
        {
            _input_radian_variable_ui.Update_Text(_input_radian.ToString());
        }

        private void Update_start_touch_vector2_variable_ui(Vector2 _start_touch_vector2)
        {
            _start_touch_vector2_variable_ui.Update_Text(_start_touch_vector2.ToString());
        }

        private void Update_touch_vector2_variable_ui(Vector2 _touch_vector2)
        {
            _touch_vector2_variable_ui.Update_Text(_touch_vector2.ToString());
        }
    }
}
# endif