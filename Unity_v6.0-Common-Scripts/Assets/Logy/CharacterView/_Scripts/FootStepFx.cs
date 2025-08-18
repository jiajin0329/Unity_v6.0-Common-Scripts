using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class FootStepFx
    {
        [SerializeField]
        private ParticleSystem footStepVfxDown;
        [SerializeField]
        private ParticleSystem footStepVfxLeft;
        [SerializeField]
        private ParticleSystem footStepVfxRight;
        [SerializeField]
        private ParticleSystem footStepVfxUp;
        [SerializeField]
        private AudioSource footStepSfx;
        private bool _canfootStepFxPlay = true;
        private float _footStepFxCooldown = 0.1f;
        public CancellationToken cancellationToken;

        public bool Play(AnimationFxEvent.FxType _fxType)
        {
            switch (_fxType)
            {
                case AnimationFxEvent.FxType.footStepRight:
                    FootStepRight();
                    return true;
                case AnimationFxEvent.FxType.footStepLeft:
                    FootStepLeft();
                    return true;
                case AnimationFxEvent.FxType.footStepUp:
                    FootStepUp();
                    return true;
                case AnimationFxEvent.FxType.footStepDown:
                    FootStepDown();
                    return true;
                default:
                    return false;
            }
        }

        private void FootStepRight()
        {
            if (!_canfootStepFxPlay) return;

            footStepVfxRight.Play();
            footStepSfx.Play();
            FootStepFxCooldown();
        }

        private void FootStepLeft()
        {
            if (!_canfootStepFxPlay) return;

            footStepVfxLeft.Play();
            footStepSfx.Play();
            FootStepFxCooldown();
        }

        private void FootStepUp()
        {
            if (!_canfootStepFxPlay) return;

            footStepVfxUp.Play();
            footStepSfx.Play();
            FootStepFxCooldown();
        }

        private void FootStepDown()
        {
            if (!_canfootStepFxPlay) return;

            footStepVfxDown.Play();
            footStepSfx.Play();
            FootStepFxCooldown();
        }

        private async void FootStepFxCooldown()
        {
            if (!_canfootStepFxPlay) return;

            _canfootStepFxPlay = false;
            await UniTask.Delay((int)(_footStepFxCooldown * 1000f), cancellationToken: cancellationToken);
            _canfootStepFxPlay = true;
        }
    }
}