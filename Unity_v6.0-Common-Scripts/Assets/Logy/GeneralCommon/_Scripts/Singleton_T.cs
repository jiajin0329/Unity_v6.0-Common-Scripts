namespace Logy.UnityCommonV01
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        public static T instance { get; private set; }

        protected Singleton() {}

        public virtual void Initialize()
        { 
            if (instance == null)
            {
                instance = (T)this;
            }
        }

        public void Destory() { instance = null; }
    }
}