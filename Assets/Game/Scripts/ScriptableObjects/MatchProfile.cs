using TowerDefender.Game.Environment;
using UnityEngine;

namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MatchProfile", menuName = "ScriptableObjects/Game/MatchProfile", order = 99)]
    public class MatchProfile : ScriptableObject
    {
        public int Coins;
        public int HP;
        public Vector3 TowerPosition;
        public Turret[] Turrets;
        public Enemy[] Enemies;
        public Vector3[] SpawnPoints;
    }
}
