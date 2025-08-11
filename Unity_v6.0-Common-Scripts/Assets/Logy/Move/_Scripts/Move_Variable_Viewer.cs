#if DEBUG
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Move_Variable_Viewer : Variable_Viewer
    {
        private Variable_UI _move_vector2_variable_ui;
        private Variable_UI _speed_ratio_variable_ui;
        private Variable_UI _move_radian_variable_ui;
        [SerializeField] private RectTransform _move_image_ui_prefab;
        private RectTransform _move_image_ui;
        private Vector2 _image_radius;
        private RectTransform _input_vector2_point;
        private RectTransform _move_vector2_point;
        private Data _data;
        public struct Data
        {
            public IInput_Model input_model;
            public IMove_Model move_model;
        }

        public void Set_Reference(Data _data) { this._data = _data; }

        public override async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await base.Initialize_With_UniTask(_cancellationToken);

            Variable_Initialize();

            _data.move_model.Tick_Action += Update_UI;
        }

        private void Variable_Initialize()
        {
            _move_vector2_variable_ui.Initialize($"{nameof(Move_Model.velocity)} : ", _variable_text);
            _speed_ratio_variable_ui.Initialize($"{nameof(Move_Model.speed_ratio)} : ", _variable_text);
            _move_radian_variable_ui.Initialize($"{nameof(Move_Model.move_radian)} : ", _variable_text);

            _move_image_ui = UnityEngine.Object.Instantiate(_move_image_ui_prefab, _variable_text.transform.parent);
            _image_radius = _move_image_ui.sizeDelta / 2f;
            _input_vector2_point = _move_image_ui.Find("input_vector2_point").GetComponent<RectTransform>();
            _move_vector2_point = _move_image_ui.Find("move_vector2_point").GetComponent<RectTransform>();
        }

        public override async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            await base.Variable_Null_Handle(_cancellationToken);

            if (Is.Variable_Null(_move_image_ui_prefab, nameof(_move_image_ui_prefab)))
            {
                GameObject _gameObject = await UniTaskEX.Addressables_LoadAssetAsync<GameObject>("Move_Image_UI", _cancellationToken);
                _move_image_ui_prefab = _gameObject.GetComponent<RectTransform>();
            }
        }

        private void Update_UI()
        {
            _move_vector2_variable_ui.Update_Text(_data.move_model.velocity.ToString());
            _speed_ratio_variable_ui.Update_Text(_data.move_model.speed_ratio.ToString());
            _move_radian_variable_ui.Update_Text(_data.move_model.move_radian.ToString());

            _input_vector2_point.anchoredPosition = _data.input_model.input_vector2 * _image_radius;
            _move_vector2_point.anchoredPosition = _data.move_model.velocity * _image_radius / Move_Model.speed;
        }
    }
}
# endif