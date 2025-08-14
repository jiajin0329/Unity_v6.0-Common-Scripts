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
        private Variable_UI _start_touch_vector2_variable_ui;
        private Variable_UI _touch_vector2_variable_ui;
        private Variable_UI _inputDonw_variable_ui;
        private Variable_UI _input_variable_ui;
        private Variable_UI _inputUp_variable_ui;
        private Variable_UI _input_vector2_variable_ui;
        private Variable_UI _input_distance_variable_ui;
        private Variable_UI _input_radian_variable_ui;

        [NonSerialized]
        public IPlayer_Input_Generic_Model _model;

        public void Set_Reference(IPlayer_Input_Generic_Model _model) { this._model = _model; }

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
            _model.input_model.InputDown_Action += Update_variable_ui;
            _model.input_model.Input_Action += Update_variable_ui;
            _model.input_model.InputUp_Action += Update_variable_ui;
        }

        private void Update_variable_ui()
        {
            _input_type_variable_ui.Update_Text(_model.controller.input_type.ToString());

            _start_touch_vector2_variable_ui.Update_Text(_model.touch_input_model.start_touch_vector2.ToString());
            _touch_vector2_variable_ui.Update_Text(_model.touch_input_model.touch_vector2.ToString());

            _inputDonw_variable_ui.Update_Text(_model.input_model.inputDown.ToString());
            _input_variable_ui.Update_Text(_model.input_model.input.ToString());
            _inputUp_variable_ui.Update_Text(_model.input_model.inputUp.ToString());
            _input_vector2_variable_ui.Update_Text(_model.input_model.input_vector2.ToString());
            _input_distance_variable_ui.Update_Text(_model.input_model.input_distance.ToString());
            _input_radian_variable_ui.Update_Text(_model.input_model.input_radian.ToString());
        }
    }
}
# endif