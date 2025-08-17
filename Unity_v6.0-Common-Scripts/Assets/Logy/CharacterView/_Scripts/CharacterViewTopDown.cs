using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public class CharacterViewTopDown
    {
        public event UnityAction DownViewAction;
        public event UnityAction LeftViewAction;
        public event UnityAction RightViewAction;
        public event UnityAction UpViewAction;

        public void Initialize()
        {
            DownViewAction = null;
            LeftViewAction = null;
            RightViewAction = null;
            UpViewAction = null;
        }

        public void DownView()
        {
            DownViewAction?.Invoke();
        }

        public void LeftView()
        {
            LeftViewAction?.Invoke();
        }

        public void RightView()
        {
            RightViewAction?.Invoke();
        }

        public void UpView()
        {
            UpViewAction?.Invoke();
        }
    }
}