using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class VirtualJoystick_View
    {
        [SerializeField]
        private RectTransform _root_ui;
        private Transform _stick_ui;
        private ITouch_Input_Model _touch_input_model;
        private IInput_Model _input_model;

        public bool is_root_ui_notNull => _root_ui != null;
        public Vector2 _root_ui_sizeDelta => _root_ui.sizeDelta;

        public void Set_Reference(ITouch_Input_Model _touch, IInput_Model _input)
        {
            _touch_input_model = _touch;
            _input_model = _input;
        }

        public async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);

            Variable_Initialize();

            Set_root_ui_sizeDelta(_touch_input_model.touch_range_radius_pixel * 2f);

            Hide_UI();
        }

        private void Set_root_ui_sizeDelta(float _set)
        {
            _root_ui.sizeDelta = new Vector2(_set, _set);
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.VariableNull(_root_ui, nameof(_root_ui)))
            {
                if (Launcher.launcherTransform != null)
                {
                    _root_ui = Launcher.launcherTransform.Find("Canvas/VirtualJoystick View UI").GetComponent<RectTransform>();
                    return;
                }

                _root_ui = await Instantiate_VirtualJoystick_View_UI(_cancellationToken);
            }
        }

        private static async UniTask<RectTransform> Instantiate_VirtualJoystick_View_UI(CancellationToken _cancellationToken)
        {
            GameObject _prefab = await UniTaskEX.AddressablesLoadAssetAsync<GameObject>("VirtualJoystick View UI", _cancellationToken);

            return GameObject.Instantiate(_prefab.GetComponent<RectTransform>()); ;
        }

        private void Variable_Initialize()
        {
            _stick_ui = _root_ui.Find("Stick");
        }

        public void Show_UI()
        {
            _root_ui.gameObject.SetActive(true);
        }

        public void Tick()
        {
            Set_UI_Position();
            Set_Stick_Position();
        }

        private void Set_UI_Position()
        {
            _root_ui.position = _touch_input_model.start_touch_vector2;
        }

        private void Set_Stick_Position()
        {
            Vector2 _localPosition = input_vector2_To_Stick_Position();
            _stick_ui.localPosition = _localPosition;
        }

        private Vector2 input_vector2_To_Stick_Position()
        {
            return _touch_input_model.touch_range_radius_pixel * _input_model.input_vector2; ;
        }

        public void Hide_UI()
        {
            _root_ui.gameObject.SetActive(false);
        }
    }
}