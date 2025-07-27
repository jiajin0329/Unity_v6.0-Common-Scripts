using System;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public struct Game_Data
    {
        [field: SerializeField] public Device_Data device { get; private set; }

        public Game_Data Initialize_With_Return()
        {
            device = device.Initialize_With_Return();

            return this;
        }
    }
}