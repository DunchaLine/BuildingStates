using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IUpgradable
    {
        public int CurrentLevel { get; }

        public int UpdateCost { get; }

        public void Update();
    }
}
