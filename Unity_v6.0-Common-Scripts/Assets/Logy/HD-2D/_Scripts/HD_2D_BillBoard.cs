using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class HD_2D_BillBoard : MonoBehaviour
    {
        private Camera _camera;
        private Transform _camera_transform;
        private Transform _transform;


        private void Awake()
        {
            _camera = Camera.main;
            _camera_transform = _camera.transform;
            _transform = transform;
        }

        private void Update()
        {
            SetForward();
        }

        private void SetForward()
        {
            if (_camera == null) return;

            Vector3 forward = Quaternion.Euler(-15f, 0f, 0f) * _camera_transform.forward;
            _transform.forward = forward;
        }
    }
}
