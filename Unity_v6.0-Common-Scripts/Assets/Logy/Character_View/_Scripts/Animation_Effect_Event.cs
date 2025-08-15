using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class Animation_Effect_Event : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem walk_down;
        [SerializeField]
        private ParticleSystem walk_left;
        [SerializeField]
        private ParticleSystem walk_right;
        [SerializeField]
        private ParticleSystem walk_up;

        private void Walk_Down()
        {
            walk_down.Play();
        }

        private void Walk_Left()
        {
            walk_left.Play();
        }

        private void Walk_Right()
        {
            walk_right.Play();
        }

        private void Walk_Up()
        {
            walk_up.Play();
        }
    }
}