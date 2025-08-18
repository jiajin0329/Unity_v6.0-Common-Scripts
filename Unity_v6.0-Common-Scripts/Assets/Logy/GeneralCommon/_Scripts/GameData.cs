using System;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public struct GameData
    {
        [field: SerializeField]
        public DeviceData device { get; private set; }

        public GameData InitializeWithReturn()
        {
            device = device.InitializeWithReturn();

            return this;
        }
    }
}