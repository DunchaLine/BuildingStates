using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Actor
{
    public class BuildingActor : ActorAbstract
    {
        public override void DisplayInfo()
        {
            Debug.Log($"Name: {name};");
            CurrentState.DisplayInfo();
        }
    }
}
