using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_View_TopDown_Presenter : Process
    {
        [field: SerializeField] public Player_View_TopDown player_view { get; private set; } = new();
        private Data _data;
        public struct Data
        {
            public Input_Model input_model;
            public IStateMachine_TopDown stateMachine;
        }

        public Player_View_TopDown_Presenter() : base(nameof(Player_View_TopDown_Presenter)) { }

        public void Set_Reference(Data _data) { this._data = _data; }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await player_view.Initialize_With_UniTask(_cancellationToken);

            Add_View_Listener();
        }

        private void Add_View_Listener()
        {
            Add_StateMachine_View_Listener();

            _data.input_model.Get_input_distance_Action += player_view.Update_Animator_Speed;
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