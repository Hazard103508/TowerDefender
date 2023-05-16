using UnityEngine;


namespace TowerDefender.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TurretProfile", menuName = "ScriptableObjects/Game/TurretProfile", order = 1)]
    public class TurretProfile : ScriptableObject
    {
        public ProjectileProfile ProjectileProfile;
        public Sprite icon;
        public float RadiusRange;
        public float FiringCoolDown;
        public int BuildCost;
    }
}
