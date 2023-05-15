using UnityEngine;


namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyProfile", menuName = "ScriptableObjects/Game/EnemyProfile", order = 3)]
    public class EnemyProfile : ScriptableObject
    {
        public float DefaultHP;
        public float Speed;
        public float DamagePoint;
        public int goldReward;
    }
}
