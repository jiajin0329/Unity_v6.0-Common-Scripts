using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class FootstepSfx : Singleton<FootstepSfx>
    {
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private Transform _parent;
        private IObjectPool<AudioSource> _pool;
        private bool isOriginalChange;

        public override void Initialize()
        {
            base.Initialize();
            _pool = new ObjectPool<AudioSource>
            (
                Create,
                Get,
                Release,
                Destory,
                true,
                2,
                10
            );
        }

        private AudioSource Create()
        {
            return UnityEngine.Object.Instantiate(_audioSource, _parent);
        }

        private void Get(AudioSource _audioSource)
        {
            ChangeOriginal(_audioSource);
            _audioSource.gameObject.SetActive(true);
            _audioSource.Play();
            AudioSourceFinish(_audioSource);
        }

        private async void AudioSourceFinish(AudioSource _audioSource)
        {
            await UniTask.Delay((int)(_audioSource.clip.length * 1000));
            _pool.Release(_audioSource);
        }

        private void ChangeOriginal(AudioSource _audioSource)
        {
            if (isOriginalChange) return;
            this._audioSource = _audioSource;
            isOriginalChange = true;
        }

        private void Release(AudioSource _audioSource)
        {
            _audioSource.gameObject.SetActive(false);
        }

        private void Destory(AudioSource _audioSource)
        {
            UnityEngine.Object.Destroy(_audioSource.gameObject);
        }

        public void Play() { _pool.Get(); }
    }
}