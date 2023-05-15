using UnityEngine;


namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BaseTowerProfile", menuName = "ScriptableObjects/Game/BaseTowerProfile", order = 0)]
    public class BaseTowerProfile : ScriptableObject
    {
        public float DefaultHP;
    }
}
