using System;
using UnityEngine;
using UnityEngine.UI;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class UI
    {
        [SerializeField]
        private GameObject _ui;
        [SerializeField]
        private Button _button;

        public void Initialize()
        {
            _button.onClick.AddListener(OpenAndClose);
        }

        private void OpenAndClose()
        {
            _ui.SetActive(!_ui.activeSelf);
        }
    }
}