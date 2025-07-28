using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public class Character_View_TopDown
    {
        public event UnityAction Down_View_Action;
        public event UnityAction Left_View_Action;
        public event UnityAction Right_View_Action;
        public event UnityAction Up_View_Action;

        public void Initialize()
        {
            Down_View_Action = null;
            Left_View_Action = null;
            Right_View_Action = null;
            Up_View_Action = null;
        }

        public void Down_View()
        {
            Down_View_Action?.Invoke();
        }

        public void Left_View()
        {
            Left_View_Action?.Invoke();
        }

        public void Right_View()
        {
            Right_View_Action?.Invoke();
        }

        public void Up_View()
        {
            Up_View_Action?.Invoke();
        }
    }
}