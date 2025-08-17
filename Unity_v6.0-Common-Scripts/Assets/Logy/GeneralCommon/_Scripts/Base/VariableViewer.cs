#if DEBUG
using UnityEngine;
using TMPro;
using System.Text;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Logy.UnityCommonV01
{
    public class VariableViewer
    {
        [SerializeField]
        protected TextMeshProUGUI _variableText;
        public bool isVariableTextNotNull => _variableText != null;
        protected struct VariableUI
        {
            private TextMeshProUGUI _text;
            private StringBuilder stringBuilder;
            private int removeStartIndex;

            public void Initialize(string _name, TextMeshProUGUI _text, bool _isInstantiate = true)
            {
                this._text = _isInstantiate ? Object.Instantiate(_text, _text.transform.parent) : _text;

                this._text.gameObject.name = _name;
                this._text.text = _name;
                stringBuilder = new StringBuilder().Append($"{_name} ");
                removeStartIndex = stringBuilder.Length;
            }

            public void UpdateText(string _string)
            {
                stringBuilder.Remove(removeStartIndex, stringBuilder.Length - removeStartIndex);
                stringBuilder.Append(_string);
                _text.text = stringBuilder.ToString();
            }
        }

        public virtual async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await VariableNullHandle(_cancellationToken);
        }

        public virtual async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            if (Is.VariableNull(_variableText, nameof(_variableText)))
            {
                if (Launcher.launcherTransform != null)
                {
                    _variableText = Launcher.launcherTransform.Find("Canvas/Variable Viewer UI/Viewport/Content").GetChild(0).GetComponent<TextMeshProUGUI>();
                    return;
                }

                _variableText = await InstantiateVariableViewerUI(_cancellationToken);
            }
        }

        private async UniTask<TextMeshProUGUI> InstantiateVariableViewerUI(CancellationToken _cancellationToken)
        {
            GameObject _prefab = await UniTaskEX.AddressablesLoadAssetAsync<GameObject>("Variable Viewer UI", _cancellationToken);

            return Object.Instantiate(_prefab).transform.Find("Viewport/Content").GetChild(0).GetComponent<TextMeshProUGUI>();
        }
    }
}
# endif