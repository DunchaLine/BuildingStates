using UnityEngine;

namespace Gameplay.Actor
{
    /// <summary>
    /// Класс актора здания
    /// </summary>
    public class BuildingActor : ActorAbstract
    {
        public override void DisplayInfo()
        {
            Debug.Log($"Name: {name};");
            if (CurrentState != null)
                CurrentState.DisplayInfo();
        }
    }
}
