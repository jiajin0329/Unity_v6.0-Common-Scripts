#if DEBUG
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class MoveVariableViewer : VariableViewer
    {
        private VariableUI _moveVector2VariableUi;
        private VariableUI _speedRatioVariableUi;
        private VariableUI _moveRadianVariableUi;
        [SerializeField] private RectTransform _moveImageUiPrefab;
        private RectTransform _moveImageUi;
        private Vector2 _imageRadius;
        private RectTransform _inputVector2Point;
        private RectTransform _moveVector2Point;
        private Data _data;
        public struct Data
        {
            public IInputModel inputModel;
            public IMoveModel moveModel;
        }

        public void SetReference(Data _data) { this._data = _data; }

        public override async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await base.InitializeWithUniTask(_cancellationToken);

            VariableInitialize();

            _data.moveModel.TickAction += UpdateUi;
        }

        private void VariableInitialize()
        {
            _moveVector2VariableUi.Initialize($"{nameof(MoveModel.velocity)} : ", _variableText);
            _speedRatioVariableUi.Initialize($"{nameof(MoveModel.speedRatio)} : ", _variableText);
            _moveRadianVariableUi.Initialize($"{nameof(MoveModel.moveRadian)} : ", _variableText);

            _moveImageUi = UnityEngine.Object.Instantiate(_moveImageUiPrefab, _variableText.transform.parent);
            _imageRadius = _moveImageUi.sizeDelta / 2f;
            _inputVector2Point = _moveImageUi.Find("input-vector2-point").GetComponent<RectTransform>();
            _moveVector2Point = _moveImageUi.Find("move-vector2-point").GetComponent<RectTransform>();
        }

        public override async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            await base.VariableNullHandle(_cancellationToken);

            if (Is.VariableNull(_moveImageUiPrefab, nameof(_moveImageUiPrefab)))
            {
                GameObject _gameObject = await UniTaskEX.AddressablesLoadAssetAsync<GameObject>("Move-Image-UI", _cancellationToken);
                _moveImageUiPrefab = _gameObject.GetComponent<RectTransform>();
            }
        }

        private void UpdateUi()
        {
            _moveVector2VariableUi.UpdateText(_data.moveModel.velocity.ToString());
            _speedRatioVariableUi.UpdateText(_data.moveModel.speedRatio.ToString());
            _moveRadianVariableUi.UpdateText(_data.moveModel.moveRadian.ToString());

            _inputVector2Point.anchoredPosition = _data.inputModel.inputVector2 * _imageRadius;
            _moveVector2Point.anchoredPosition = _data.moveModel.velocity * _imageRadius / MoveModel.speed;
        }
    }
}
# endif