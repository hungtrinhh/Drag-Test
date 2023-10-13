using Unity.VisualScripting;
using Update = UnityEngine.PlayerLoop.Update;

namespace Extension.Observer
{
    public class OnPlayerScaleChange : Subject
    {
        void Update()
        {
            if (transform.localScale.x > 1)
            {
                this.Action?.Invoke();
            }
        }
    }
}