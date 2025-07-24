using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class VirtualJoystick_View : Process
    {        
        [SerializeField] private RectTransform _root_ui;
        private Transform _stick_ui;
        public float touch_range_radius_pixel { get; private set; }

        public bool is_root_ui_notNull => _root_ui != null;
        public Vector2 _root_ui_sizeDelta => _root_ui.sizeDelta;

        public VirtualJoystick_View() : base(nameof(VirtualJoystick_View)) {}

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);

            Variable_Initialize();

            Hide_UI();
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.Variable_Null(_root_ui, nameof(_root_ui)))
            {
                if (Launcher.launcher_transform != null)
                {
                    _root_ui = Launcher.launcher_transform.Find("Canvas/VirtualJoystick View UI").GetComponent<RectTransform>();
                    return;
                }

                _root_ui = await Instantiate_VirtualJoystick_View_UI(_cancellationToken);
            }
        }

        private static async UniTask<RectTransform> Instantiate_VirtualJoystick_View_UI(CancellationToken _cancellationToken)
        {
            GameObject _prefab = await UniTaskEX.Addressables_LoadAssetAsync<GameObject>("VirtualJoystick View UI", _cancellationToken);

            return GameObject.Instantiate(_prefab.GetComponent<RectTransform>()); ;
        }

        private void Variable_Initialize()
        {
            _stick_ui = _root_ui.Find("Stick");
        }

        public void Set_touch_range_radius_pixel(float _touch_range_radius_pixel)
        {
            touch_range_radius_pixel = _touch_range_radius_pixel;
            Set_root_ui_sizeDelta(_touch_range_radius_pixel * 2f);
        }

        private void Set_root_ui_sizeDelta(float _set)
        {
            _root_ui.sizeDelta = new Vector2(_set, _set);
        }

        public void Show_UI()
        {
            _root_ui.gameObject.SetActive(true);
        }

        public void Hide_UI()
        {
            _root_ui.gameObject.SetActive(false);
        }

        public void Set_UI_Position(Vector2 _start_touch_vector2)
        {
            _root_ui.position = _start_touch_vector2;
        }

        public void Set_Stick_Position(Vector2 _input_vector2)
        {
            Vector2 _localPosition = input_vector2_To_Stick_Position(_input_vector2);
            _stick_ui.localPosition = _localPosition;
        }

        private Vector2 input_vector2_To_Stick_Position(Vector2 _input_vector2)
        {
            return touch_range_radius_pixel * _input_vector2;
        }
    }
}