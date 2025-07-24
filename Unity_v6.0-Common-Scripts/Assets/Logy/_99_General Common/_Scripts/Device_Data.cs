using System;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Device_Data : Process
    {
        [field: SerializeField] public float dpi { get; private set; }

        public Device_Data() : base(nameof(Device_Data)) {}

        protected override void Initialize_Detail()
        {
            dpi = Screen.dpi;
        }
    }
}