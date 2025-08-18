using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class VirtualJoystickView
    {
        [SerializeField]
        private RectTransform _rootUi;
        private Transform _stickUi;
        private ITouchInputModel _touchInputModel;
        private IInputModel _inputModel;

        public bool isRootUiNotNull => _rootUi != null;
        public Vector2 rootUiSizeDelta => _rootUi.sizeDelta;

        public void SetReference(ITouchInputModel _touch, IInputModel _input)
        {
            _touchInputModel = _touch;
            _inputModel = _input;
        }

        public async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await VariableNullHandle(_cancellationToken);
            VariableInitialize();
            SetRootUiSizeDelta(_touchInputModel.touchRangeRadiusPixel * 2f);
            HideUi();
        }

        private void SetRootUiSizeDelta(float _set)
        {
            _rootUi.sizeDelta = new Vector2(_set, _set);
        }

        public async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            if (Is.VariableNull(_rootUi, nameof(_rootUi)))
            {
                if (Launcher.launcherTransform != null)
                {
                    _rootUi = Launcher.launcherTransform.Find("Canvas/VirtualJoystick-View-UI").GetComponent<RectTransform>();
                    return;
                }

                _rootUi = await InstantiateVirtualJoystickViewUi(_cancellationToken);
            }
        }

        private static async UniTask<RectTransform> InstantiateVirtualJoystickViewUi(CancellationToken _cancellationToken)
        {
            GameObject _prefab = await UniTaskEX.AddressablesLoadAssetAsync<GameObject>("VirtualJoystick-View-UI", _cancellationToken);

            return UnityEngine.Object.Instantiate(_prefab.GetComponent<RectTransform>()); ;
        }

        private void VariableInitialize()
        {
            _stickUi = _rootUi.Find("Stick");
        }

        public void ShowUi()
        {
            _rootUi.gameObject.SetActive(true);
        }

        public void Tick()
        {
            SetUiPosition();
            SetStickPosition();
        }

        private void SetUiPosition()
        {
            _rootUi.position = _touchInputModel.startTouchVector2;
        }

        private void SetStickPosition()
        {
            Vector2 _localPosition = InputVector2ToStickPosition();
            _stickUi.localPosition = _localPosition;
        }

        private Vector2 InputVector2ToStickPosition()
        {
            return _touchInputModel.touchRangeRadiusPixel * _inputModel.inputVector2; ;
        }

        public void HideUi()
        {
            _rootUi.gameObject.SetActive(false);
        }
    }
}