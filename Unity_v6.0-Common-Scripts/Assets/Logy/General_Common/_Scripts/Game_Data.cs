using System;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Game_Data : Process
    {
        [field: SerializeField] public Device_Data device { get; private set; } = new();

        public Game_Data() : base(nameof(Device_Data)) {}

        protected override void Initialize_Detail()
        {
            device.Initialize();
        }
    }
}