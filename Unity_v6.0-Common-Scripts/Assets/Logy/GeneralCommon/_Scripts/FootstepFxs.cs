using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class FootstepFxs
    {
        [SerializeField]
        private ParticleSystem footstepVfxDown;
        [SerializeField]
        private ParticleSystem footstepVfxLeft;
        [SerializeField]
        private ParticleSystem footstepVfxRight;
        [SerializeField]
        private ParticleSystem footstepVfxUp;
        private bool _canFootstepFxPlay = true;
        private float _footstepFxCooldown = 0.1f;
        public CancellationToken cancellationToken;

        public bool Play(AnimationFxEvent.FxType _fxType)
        {
            switch (_fxType)
            {
                case AnimationFxEvent.FxType.footstepRight:
                    FootstepRight();
                    return true;
                case AnimationFxEvent.FxType.footstepLeft:
                    FootstepLeft();
                    return true;
                case AnimationFxEvent.FxType.footstepUp:
                    FootstepUp();
                    return true;
                case AnimationFxEvent.FxType.footstepDown:
                    FootstepDown();
                    return true;
                default:
                    return false;
            }
        }

        private void FootstepRight()
        {
            if (!_canFootstepFxPlay) return;

            footstepVfxRight.Play();
            FootstepSfx.instance.Play();
            FootstepFxCooldown();
        }

        private void FootstepLeft()
        {
            if (!_canFootstepFxPlay) return;

            footstepVfxLeft.Play();
            FootstepSfx.instance.Play();
            FootstepFxCooldown();
        }

        private void FootstepUp()
        {
            if (!_canFootstepFxPlay) return;

            footstepVfxUp.Play();
            FootstepSfx.instance.Play();
            FootstepFxCooldown();
        }

        private void FootstepDown()
        {
            if (!_canFootstepFxPlay) return;

            footstepVfxDown.Play();
            FootstepSfx.instance.Play();
            FootstepFxCooldown();
        }

        private async void FootstepFxCooldown()
        {
            if (!_canFootstepFxPlay) return;

            _canFootstepFxPlay = false;
            await UniTask.Delay((int)(_footstepFxCooldown * 1000f), cancellationToken: cancellationToken);
            _canFootstepFxPlay = true;
        }
    }
}