using TowerDefender.Commons;
using UnityEngine;


namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TurretProfile", menuName = "ScriptableObjects/Game/TurretProfile", order = 0)]
    public class TurretProfile : ScriptableObject
    {
        public GameObject Prefab;
        public ProjectileProfile ProjectileProfile;
        public float FiringFrequency;
        public int BuildCost;
        public Sprite icon;
        public RangeNumber<float> RadiusRange;
    }
}
