using UnityEngine;

namespace Logy.UnityCommonV01
{
    public class HD2DBillBoard : MonoBehaviour
    {
        private Camera _camera;
        private Transform _cameraTransform;
        private Transform _transform;


        private void Awake()
        {
            _camera = Camera.main;
            _cameraTransform = _camera.transform;
            _transform = transform;
        }

        private void Update()
        {
            SetForward();
        }

        private void SetForward()
        {
            if (_camera == null) return;

            Vector3 forward = Quaternion.Euler(-15f, 0f, 0f) * _cameraTransform.forward;
            _transform.forward = forward;
        }
    }
}
