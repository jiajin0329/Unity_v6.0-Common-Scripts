using System;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public struct Device_Data
    {
        [field: SerializeField] public float dpi { get; private set; }

        public Device_Data Initialize_With_Return()
        {
            dpi = Screen.dpi;

            return this;
        }
    }
}