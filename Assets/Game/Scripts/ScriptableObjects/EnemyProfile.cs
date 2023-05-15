using UnityEngine;


namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyProfile", menuName = "ScriptableObjects/Game/EnemyProfile", order = 3)]
    public class EnemyProfile : ScriptableObject
    {
        public int DefaultHP;
        public float Speed;
        public int DamagePoint;
        public int goldReward;
    }
}
