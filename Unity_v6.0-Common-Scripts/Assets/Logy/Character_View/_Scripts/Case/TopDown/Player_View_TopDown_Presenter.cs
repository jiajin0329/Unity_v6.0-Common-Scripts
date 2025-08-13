using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_View_TopDown_Presenter : Process, IHas_Initialize_With_UniTask
    {
        [field: SerializeField]
        public Player_View_TopDown player_view { get; private set; } = new();
        private Data _data;
        public struct Data
        {
            public Transform parent;
            public IMove_Model move_model;
            public IStateMachine_TopDown stateMachine;
        }

        public Player_View_TopDown_Presenter() : base(nameof(Player_View_TopDown_Presenter)) {}

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            await player_view.Variable_Null_Handle(_cancellationToken);
        }

        public void Set_Reference(Data _data)
        {
            this._data = _data;

            Player_View_TopDown.Data player_view_data = new()
            {
                parent = _data.parent,
                move_model = _data.move_model
            };
            player_view.Set_Reference(player_view_data);
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await player_view.Initialize_With_UniTask(_cancellationToken);

            Add_View_Listener();
        }

        private void Add_View_Listener()
        {
            _data.move_model.Tick_Action += player_view.Update_Animator_Speed;

            Add_StateMachine_View_Listener();
        }

        private void Add_StateMachine_View_Listener()
        {
            for (byte i = 0; i < player_view.views.Length; i++)
            {
                _data.stateMachine.sates[i].OnDown_Action += player_view.views[i].Down_View;
                _data.stateMachine.sates[i].OnLeft_Action += player_view.views[i].Left_View;
                _data.stateMachine.sates[i].OnRight_Action += player_view.views[i].Right_View;
                _data.stateMachine.sates[i].OnUp_Action += player_view.views[i].Up_View;
            }
        }
    }
}