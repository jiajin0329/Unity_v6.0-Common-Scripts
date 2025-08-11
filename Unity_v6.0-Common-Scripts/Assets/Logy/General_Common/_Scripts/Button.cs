using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class Button : MonoBehaviour
    {
        public void Open_And_Close_UI(GameObject _ui)
        {
            _ui.SetActive(!_ui.activeSelf);
        }
    }
}