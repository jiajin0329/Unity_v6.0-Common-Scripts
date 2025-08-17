using System;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public struct DeviceData
    {
        [field: SerializeField] public float dpi { get; private set; }

        public DeviceData InitializeWithReturn()
        {
            dpi = Screen.dpi;

            return this;
        }
    }
}