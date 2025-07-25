#if DEBUG
using UnityEngine;
using TMPro;
using System.Text;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Logy.Unity_Common_v01
{
    public class Variable_Viewer : Process
    {
        [SerializeField] protected TextMeshProUGUI _variable_text;
        public bool is_variable_text_notNull => _variable_text != null;
        protected struct Variable_UI
        {
            private TextMeshProUGUI _text;
            private StringBuilder stringBuilder;
            private int remove_startIndex;

            public void Initialize(string _name, TextMeshProUGUI _text, bool _is_instantiate = true)
            {
                this._text = _is_instantiate ? Object.Instantiate(_text, _text.transform.parent) : _text;

                this._text.gameObject.name = _name;
                this._text.text = _name;
                stringBuilder = new StringBuilder().Append($"{_name} ");
                remove_startIndex = stringBuilder.Length;
            }

            public void Update_Text(string _string)
            {
                stringBuilder.Remove(remove_startIndex, stringBuilder.Length - remove_startIndex);
                stringBuilder.Append(_string);
                _text.text = stringBuilder.ToString();
            }
        }

        public Variable_Viewer(string _name) : base(_name) {}

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.Variable_Null(_variable_text, nameof(_variable_text)))
            {
                if (Launcher.launcher_transform != null)
                {
                    _variable_text = Launcher.launcher_transform.Find("Canvas/Variable Viewer UI/Viewport/Content").GetChild(0).GetComponent<TextMeshProUGUI>();
                    return;
                }

                _variable_text = await Instantiate_Variable_Viewer_UI(_cancellationToken);
            }
        }

        private async UniTask<TextMeshProUGUI> Instantiate_Variable_Viewer_UI(CancellationToken _cancellationToken)
        {
            GameObject _prefab = await UniTaskEX.Addressables_LoadAssetAsync<GameObject>("Variable Viewer UI", _cancellationToken);

            return Object.Instantiate(_prefab).transform.Find("Viewport/Content").GetChild(0).GetComponent<TextMeshProUGUI>();
        }
    }
}
# endif