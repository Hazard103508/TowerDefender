using System;
using TowerDefender.Commons;
using TowerDefender.Game.Environment;
using UnityEngine;


namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TurretProfile", menuName = "ScriptableObjects/Game/TurretProfile", order = 1)]
    public class TurretProfile : ScriptableObject
    {
        public TurretPrefabs Prefabs;
        public ProjectileProfile ProjectileProfile;
        public Sprite icon;
        public float RadiusRange;
        public float FiringFrequency;
        public int BuildCost;

        [Serializable]
        public class TurretPrefabs
        {
            public GameObject Turret;
            public TurretRange Range;
        }
    }
}
