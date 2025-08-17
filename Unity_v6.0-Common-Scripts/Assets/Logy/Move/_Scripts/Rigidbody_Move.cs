using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class Rigidbody_Move : Process, IHasInitializeWithUniTask, IHasTick
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        public Transform transform { get; private set; }
        [SerializeField]
        private Move_Model _move_model = new();
        public IMove_Model move_model => _move_model;

#if DEBUG
        [SerializeField]
        private Move_Variable_Viewer _move_variable_viewer = new();
#endif

        public Rigidbody_Move() : base(nameof(Rigidbody_Move)) {}

        public void Set_Reference(IInput_Model input_model)
        {
            _move_model.Set_Reference(input_model);

            Move_Variable_Viewer.Data _move_variable_viewer_data = new()
            {
                input_model = input_model,
                move_model = _move_model,
            };
#if DEBUG
            _move_variable_viewer.Set_Reference(_move_variable_viewer_data);
#endif
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.VariableNull(_rigidbody, nameof(_rigidbody)))
            {
                GameObject _load = await UniTaskEX.Addressables_LoadAssetAsync<GameObject>("Rigidbody", _cancellationToken);
                _rigidbody = _load.GetComponent<Rigidbody>();
            }

            await _move_variable_viewer.VariableNullHandle(_cancellationToken);
        }

        protected override async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);
            _rigidbody = UnityEngine.Object.Instantiate(_rigidbody, new Vector3(0f, 0f, -2.5f), Quaternion.identity);
            transform = _rigidbody.transform;

            _move_model.Initialize();

            await _move_variable_viewer.InitializeWithUniTask(_cancellationToken);
        }

        protected override void TickDetail()
        {
            _move_model.Tick();

            Vector2 _velocity = _move_model.velocity;
            _rigidbody.linearVelocity = new Vector3(_velocity.x, _rigidbody.linearVelocity.y, _velocity.y);
        }
    }
}