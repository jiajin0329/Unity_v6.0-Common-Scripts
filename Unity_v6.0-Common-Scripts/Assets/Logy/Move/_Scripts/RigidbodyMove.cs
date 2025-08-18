using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class RigidbodyMove : Process, IHasInitializeWithUniTask, IHasTick
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        public Transform transform { get; private set; }
        [SerializeField]
        private MoveModel _moveModel = new();
        public IMoveModel moveModel => _moveModel;

#if DEBUG
        [SerializeField]
        private MoveVariableViewer _moveVariableViewer = new();
#endif

        public RigidbodyMove() : base(nameof(RigidbodyMove)) {}

        public void SetReference(IInputModel inputModel)
        {
            _moveModel.SetReference(inputModel);

            MoveVariableViewer.Data _data = new()
            {
                inputModel = inputModel,
                moveModel = _moveModel,
            };
#if DEBUG
            _moveVariableViewer.SetReference(_data);
#endif
        }

        public async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            if (Is.VariableNull(_rigidbody, nameof(_rigidbody)))
            {
                GameObject _load = await UniTaskEX.AddressablesLoadAssetAsync<GameObject>("Rigidbody", _cancellationToken);
                _rigidbody = _load.GetComponent<Rigidbody>();
            }

            await _moveVariableViewer.VariableNullHandle(_cancellationToken);
        }

        protected override async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            await VariableNullHandle(_cancellationToken);
            _rigidbody = UnityEngine.Object.Instantiate(_rigidbody, new Vector3(0f, 0f, -2.5f), Quaternion.identity);
            transform = _rigidbody.transform;

            _moveModel.Initialize();

            await _moveVariableViewer.InitializeWithUniTask(_cancellationToken);
        }

        protected override void TickDetail()
        {
            _moveModel.Tick();

            Vector2 _velocity = _moveModel.velocity;
            _rigidbody.linearVelocity = new Vector3(_velocity.x, _rigidbody.linearVelocity.y, _velocity.y);
        }
    }
}