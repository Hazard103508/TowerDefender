using UnityEngine;


namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WaveProfile", menuName = "ScriptableObjects/Game/WaveProfile", order = 4)]
    public class WaveProfile : ScriptableObject
    {
        public int EnemyCount;
        public float SpawnFrequency;
        public float CoolDownTime;
    }
}
